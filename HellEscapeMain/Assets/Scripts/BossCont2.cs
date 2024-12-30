using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class BossCont2 : MonoBehaviour, IKillable
{

    [SerializeField] private GameObject aidKitPrefab, upgradePrefab, bloodParticle;
    [SerializeField] private Slider bossSlider;
    [SerializeField] private Image sliderImage;
    [SerializeField] private Color maxHealthColor, minHealthColor;
    private Vector3 direction;
    private Transform player;
    private MySolidSpawner Parent;
    private Status bossStatus;
    private CharacterAnimation bossAnimation;
    private CharacterMovement bossMovement;
    private float probabilityupgrade = .5f;
    private ScreenController screenController;
    private Collider coll;
    public bool dead;
    private NavMeshAgent agent;
    private void Awake()
    {
        coll = GetComponent<Collider>();
        player = SharedVariables.Instance.playa.transform;
        screenController = SharedVariables.Instance.screenCont;
        bossStatus = GetComponent<Status>();
        Parent = SharedVariables.Instance.spawner;
        bossAnimation = GetComponent<CharacterAnimation>();
        bossMovement = GetComponent<CharacterMovement>();
        agent=GetComponent<NavMeshAgent>(); 
    }
    private void OnEnable()
    {
        
        Parent.BossHere = true;       
        screenController.ShowBossText();
        UpdateInterface();
        bossStatus.health = bossStatus.initialHealth;
        bossSlider.maxValue = bossStatus.initialHealth;
        bossSlider.value = bossStatus.health;
        sliderImage.color = Color.green;
        coll.enabled = true;
        dead = false;
        if (agent!=null)
        {
            agent.enabled=true;
        }
    }
    private void OnDisable()
    {
        Parent.BossHere = false;
    }
    void FixedUpdate()
    {
        if (!dead)
        {
            // get the distance between this enemy and the player
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (direction != Vector3.zero&&agent==null)
            {
                bossMovement.Rotation(direction);
            }
            bossAnimation.Movemento(direction.magnitude * 5);
       
            if (distance > 3.5f)
            {
                if (agent != null)
                {
                    direction = player.transform.position;
                    bossMovement.Movement(direction);
                }
                else
                {
                    // the distance between the enemy and the player
                    direction = player.transform.position - transform.position;

                    bossMovement.Movemento(direction, bossStatus.speed);
                }
                
                // if they're not colliding the Attacking animation is off
                bossAnimation.Attack(false);
            }
            else
            {
                if (agent != null)
                {
                    direction = player.transform.position;
                   
                }
                else
                {
                    direction = player.transform.position - transform.position;
                }
              
                // otherwise, the Attacking animation is on
                bossAnimation.Attack(true);
            }
        }
       
    }

    private void AttackPlayer()
    {
        int damage = Random.Range(30, 40);
        player.GetComponent<PlayerController>().LoseHealth(damage);
    }

    public void LoseHealth(int damage)
    {
        bossStatus.health -= damage;
        UpdateInterface();
        if (bossStatus.health <= 0)
            Die();
 
    }

    public void Die()
    {
        dead = true;
        StartCoroutine(Dying());
        //Destroy(gameObject, 2);
        bossAnimation.Die();
        bossMovement.Die();
        Instantiate(aidKitPrefab, transform.position+Vector3.up, Quaternion.identity);
        //enabled = false;
        InstantiateUpgrade(probabilityupgrade);
        if (agent!=null)
        {
          agent.enabled = false;    
        }
    }
    IEnumerator Dying()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);

    }
    public void BloodParticle(Vector3 position, Quaternion rotation)
    {
        Instantiate(bloodParticle, position, rotation);
    }

    private void UpdateInterface()
    {
        bossSlider.value = bossStatus.health;
        float healthPercent = (float)bossStatus.health / bossStatus.initialHealth;
        Color healthColor = Color.Lerp(minHealthColor, maxHealthColor, healthPercent);
        sliderImage.color = healthColor;
    }
    private void InstantiateUpgrade(float probability)
    {
        if (Random.value <= probability)
            Instantiate(upgradePrefab, new Vector3(transform.position.x+2,0,transform.position.z), Quaternion.identity);
    }
}