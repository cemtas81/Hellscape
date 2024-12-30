using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using DamageNumbersPro;
using UnityEngine.AI;
using cakeslice;
using Unity.Collections;
using Unity.Jobs;
using Unity.Burst;
using DG.Tweening;

public class EnemyController :MonoBehaviour, IKillable
{
    public enum EnemyState { Idle, Chasing, Attacking, Dying, KickReward }

    [HideInInspector] public EnemySpawner EnemySpawner;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private GameObject aidKit;
    [SerializeField] private ParticleSystem bloodParticle;
    public Outline outLine;
    public DamageNumber numberPrefab;
    private GameObject targetObject;
    public Detector detector;
    private Status enemyStatus;
    private GameObject player;
    private CharacterMovement enemyMovement;
    private CharacterAnimation enemyAnimation;
    private ScreenController screenController;
    private NavMeshAgent agent;
    private Collider coll;
    private Rigidbody rb;
    public EnemyState currentState;
    private Vector3 direction;
    private float probabilityAidKit = 0.03f, distance;
    private MySolidSpawner Parent;
    private CancellationTokenSource cancellationTokenSource;
    private GameObject camCrack;
    Camera cam;

    [BurstCompile]
    public struct DistanceJob : IJob
    {
        public Vector3 playerPosition;
        public Vector3 enemyPosition;
        public NativeArray<float> result;

        public void Execute()
        {
            result[0] = Vector3.Distance(playerPosition, enemyPosition);
        }
    }
    private void Awake()
    {
        enemyMovement = GetComponent<CharacterMovement>();
        enemyAnimation = GetComponent<CharacterAnimation>();
        enemyStatus = GetComponent<Status>();
        screenController = SharedVariables.Instance.screenCont;
        Parent = SharedVariables.Instance.spawner;
        player = SharedVariables.Instance.playa;
        coll = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        cam = SharedVariables.Instance.cam;
        camCrack = SharedVariables.Instance.crackCam.gameObject;
    }

    private void OnEnable()
    {
        cancellationTokenSource = new CancellationTokenSource();
        Parent.spawnedPrefabs.Add(this.gameObject);
        if (agent != null) agent.enabled = true;
        rb.isKinematic = false;
        enemyStatus.health = enemyStatus.initialHealth;
        coll.enabled = true;
        currentState = EnemyState.Idle;
        targetObject = null;
        _ = StartStateHandling(cancellationTokenSource.Token);
    }

    private void OnDisable()
    {
        cancellationTokenSource.Cancel();
        cancellationTokenSource.Dispose();
        //cancellationTokenSource = new CancellationTokenSource();
        Parent.spawnedPrefabs.Remove(this.gameObject);
    }

    private async UniTask StartStateHandling(CancellationToken token)
    {
        NativeArray<float> distanceResult = new(1, Allocator.Persistent); // Change to Persistent allocator

        try
        {
            while (!token.IsCancellationRequested)
            {
                await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);

                // Schedule the distance calculation job
                DistanceJob distanceJob = new()
                {
                    playerPosition = targetObject != null ? targetObject.transform.position : player.transform.position,
                    enemyPosition = transform.position,
                    result = distanceResult
                };

                JobHandle jobHandle = distanceJob.Schedule();
                jobHandle.Complete();

                // Retrieve the result
                distance = distanceResult[0];

                // Update the movement based on the calculated distance
                HandleState();
                //await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);
            }
        }
        finally
        {
            distanceResult.Dispose(); // Ensure the NativeArray is disposed in the finally block
        }
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case EnemyState.Idle:
                enemyAnimation.Attack(false);
                break;
            case EnemyState.Chasing:
                enemyAnimation.Attack(false);
                break;
            case EnemyState.Attacking:
                enemyAnimation.Attack(true);
                break;
            case EnemyState.KickReward:
                enemyAnimation.Attack(false);
                break;
            case EnemyState.Dying:
                _=DyingRoutineAsync(cancellationTokenSource.Token);
                break;

        }
    }

    private void HandleState()
    {

        switch (currentState)
        {
            case EnemyState.Idle:
                if (targetObject == null)
                    ChangeState(EnemyState.Chasing);
                else
                    ChangeState(EnemyState.KickReward); 
                break;

            case EnemyState.Chasing:
                if (distance <= 3f)
                {
                    ChangeState(EnemyState.Attacking);
                }
                else
                {
                    MoveTowardsPlayer();
                }
                break;

            case EnemyState.Attacking:
                if (distance > 3f)
                {
                    ChangeState(EnemyState.Chasing);
                }
                else
                {
                    if (targetObject == null)
                    {
                        Attack();
                    }

                }
                break;

            case EnemyState.KickReward:
                if (detector.detected)
                {
                    if (distance <= 2f)
                    {
                        KickTarget();
                    }
                    else
                    {
                        MoveTowardsTarget();
                    }
                }

                break;

            case EnemyState.Dying:
                break;
        }
    }
    private void KickTarget()
    {
        if (targetObject != null)
        {
            enemyAnimation.Kicko(true);
            if (agent.enabled)
            {
                agent.isStopped = true; // Stop NavMeshAgent from moving
            }
        }
        else
        {
            enemyAnimation.Kicko(false);
          
        }
    }

    public void Kick()
    {
        
        detector.Reward.transform.DOMove(camCrack.transform.position, 0.5f)
            .SetEase(Ease.InOutCirc)
            .OnComplete(() =>
            {
                if (!camCrack.activeSelf)
                {
                    detector.Reward.SetActive(false);
                    camCrack.SetActive(true);
                    
                }
            });
        targetObject = null;

        //_ = KickRoutineAsync(cancellationTokenSource.Token);
    }

    public void MoveOn()
    {
        if (agent.enabled)
        {
            agent.isStopped = false; // Resume NavMeshAgent
        }
        enemyAnimation.Kicko(false);
        //ChangeState(EnemyState.Chasing);
        //MoveTowardsPlayer();
    }
    private void Attack()
    {

        direction = player.transform.position;
        direction.y = transform.position.y;
        transform.LookAt(direction);
    }
    private void MoveTowardsTarget()
    {

        if (detector != null)
        {
            targetObject = detector.Reward;
        }
        if (targetObject != null)
        {
            direction = targetObject.transform.position - transform.position;
            direction.y = 0;

            if (agent.enabled)
            {
                agent.SetDestination(targetObject.transform.position);
            }

            enemyAnimation.Movemento(direction.magnitude * 5);
        }
    }
    private void MoveTowardsPlayer()
    {
        direction = player.transform.position - transform.position;
        direction.y = 0;

        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position);
        }

        enemyAnimation.Movemento(direction.magnitude * 5);
    }

    private void AttackPlayer()
    {
        int damage = Random.Range(5, 10);
        player.GetComponent<PlayerController>().LoseHealth(damage);
    }

    public void LoseHealth(int damage)
    {
        enemyStatus.health -= damage;

        if (outLine != null && outLine.eraseRenderer)
        {
            outLine.eraseRenderer = false;
            _=UnOutlineAsync(cancellationTokenSource.Token);
        }

        if (enemyStatus.health <= 0)
        {
            DamageN(0.5f, "100");
            ChangeState(EnemyState.Dying);
        }
        else
        {
            DamageN(1.5f, "50");
        }
    }

    private async UniTask UnOutlineAsync(CancellationToken token)
    {
        await UniTask.Delay(100, cancellationToken: token);
        outLine.eraseRenderer = true;
    }

    private async UniTask DyingRoutineAsync(CancellationToken token)
    {
        enemyAnimation.Die();
        enemyMovement.Die();

        if (agent != null)
        {
            agent.enabled = false;
        }

        screenController.UpdateDeadZombiesCount();
        Parent.Spawn3(transform.position);
        AudioController.instance.PlayOneShot(deathSound);

        InstantiateAidKit(probabilityAidKit);

        await UniTask.Delay(1500, cancellationToken: token);
        gameObject.SetActive(false);
    }

    private void InstantiateAidKit(float probability)
    {
        if (Random.value <= probability)
            Instantiate(aidKit, transform.position + Vector3.up, Quaternion.identity);
    }

    public void BloodParticle(Vector3 position, Quaternion rotation)
    {
        bloodParticle.transform.SetPositionAndRotation(position, rotation);
        bloodParticle.Play();
    }

    private void DamageN(float value, string st)
    {
        DamageNumber damageNumber = numberPrefab.Spawn(transform.position + Vector3.up * value, st);
    }

    public void Die()
    {
        _=DyingRoutineAsync(cancellationTokenSource.Token);
    }
}
