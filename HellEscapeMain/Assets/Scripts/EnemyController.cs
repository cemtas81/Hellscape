using System.Collections;
using UnityEngine;
using DamageNumbersPro;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IKillable 
{

	[HideInInspector] public EnemySpawner EnemySpawner;
	
	[SerializeField] private AudioClip deathSound;
	[SerializeField] private GameObject aidKit;
	[SerializeField] private GameObject bloodParticle;
	//[SerializeField] private GameObject deadEnd;
	
	private Status enemyStatus;
	private GameObject player;
	private CharacterMovement enemyMovement;
	private CharacterAnimation enemyAnimation;
	private ScreenController screenController;
	private Vector3 randomPosition;
	private Vector3 direction;
	private float rollingCounter;
	private float randomPositionTime = 4;
	private float probabilityAidKit = .05f;
    private MySolidSpawner Parent;
	public DamageNumber numberPrefab;
	private NavMeshAgent agent;
    void Start () {
	
		enemyMovement = GetComponent<CharacterMovement>();
		enemyAnimation = GetComponent<CharacterAnimation>();
		enemyStatus = GetComponent<Status>();
		screenController = SharedVariables.screenController_m;	
		Parent = SharedVariables.Spawner;
		player=SharedVariables.hero;	
        //GetRandomEnemy();
		Parent.spawnedPrefabs.Add(this.gameObject);
		enabled = true;
		agent = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate () {

		// get the distance between this enemy and the player
		float distance = Vector3.Distance(transform.position, player.transform.position);
		if (direction != Vector3.zero&&agent==null)
		{
			direction.y = 0;
			enemyMovement.Rotation(direction);
		}

		enemyAnimation.Movement(direction.magnitude*5);
        if (distance > 60)
        {
            Parent.spawnedPrefabs.Remove(this.gameObject);
            Destroy(gameObject);
            //this.gameObject.SetActive(false);
            
			enabled = false;
        }
  //      else if (distance > 30) 
		//{
		//	Rolling();
		//} 
		else if (distance > 3f) 
		{
		
			direction = player.transform.position - transform.position;

			// checks if enemy and player are not colliding.
			// The 2.5f is because both enemy and player have a Capsule Collider with radius equal 1,
			// so if the distance is bigger than both radius they are colliding
			if (agent!=null)
			{
				direction=player.transform.position;
                enemyMovement.Movement(direction);
            }
			else
			enemyMovement.Movement(direction, enemyStatus.speed);
			
			// if they're not colliding the Attacking animation is off
			enemyAnimation.Attack(false);
		} 
		else
		{
			if (agent!=null)
			{
				direction = player.transform.position;
				enemyAnimation.Attack(true);
            }
			else
			direction = player.transform.position - transform.position;
			// otherwise, the Attacking animation is on
			enemyAnimation.Attack(true);
		}
	}
	
	/// <summary>
	/// Attacks the player, causing a random damage between 20 and 30.
	/// </summary>
	void AttackPlayer () {
		int damage = Random.Range(5, 10);
		player.GetComponent<PlayerController>().LoseHealth(damage);
		
	}

	void GetRandomEnemy () {
		// gets a random enemy
		// (the Zombie prefab has 27 different zombie models inside it)
		int randomEnemy = Random.Range(1, transform.childCount);
		transform.GetChild(randomEnemy).gameObject.SetActive(true);
	}

	public void LoseHealth(int damage)
	{
		enemyStatus.health -= damage;

		if (enemyStatus.health <= 0)
		{
			DamageN(.5f, "execution");
			Die();
		}
		else
			DamageN(1.5f, "hit");
	}

	public void Die() {
		Destroy(gameObject, 1.5f);
		enemyAnimation.Die();
	    enemyMovement.Die();
        enemyStatus.speed= 0;
        enabled = false;
		if (agent!=null)
		{
            agent.enabled = false;
        }		
        screenController.UpdateDeadZombiesCount();
        //EnemySpawner.DecreaseAliveEnemiesAmount();
        Parent.Spawn3(this.transform.position);
        Parent.spawnedPrefabs.Remove(this.gameObject);
        // plays the death sound
        AudioController.instance.PlayOneShot(deathSound);
		InstantiateAidKit (probabilityAidKit);
		//Bloody(this.transform.position, Quaternion.identity);
	}
   
    public void BloodParticle(Vector3 position, Quaternion rotation) {
		Instantiate(bloodParticle, position, rotation);
	} 
	//public void Bloody(Vector3 position, Quaternion rotation)
	//{
	//	Instantiate(deadEnd, position, rotation);
	//}

	private void InstantiateAidKit (float probability) {
		if (Random.value <= probability)
			Instantiate(aidKit, transform.position, Quaternion.identity);
	}

	//private void Rolling () {
	//	rollingCounter -= Time.deltaTime;
	//	if (rollingCounter <= 0) {
	//		randomPosition = GetRandomPosition();
	//		rollingCounter += randomPositionTime + Random.Range(-1f, 1f);
	//	}

	//	bool closeEnough = Vector3.Distance(transform.position, randomPosition) <= 0.1;
	//	if (!closeEnough) {
	//		direction = randomPosition - transform.position;
	//		enemyMovement.Movement(direction, enemyStatus.speed);
	//	}
	//}

	//private Vector3 GetRandomPosition () {
	//	Vector3 position = Random.insideUnitSphere * 10;
	//	position += transform.position;
	//	position.y = transform.position.y;
	//	return position;
	//}
    void DamageN(float value, string st)
    {
		DamageNumber damageNumber = numberPrefab.Spawn(transform.position + Vector3.up * value, st);
	}
}
