using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour {

	private Rigidbody myRigidbody;
	private NavMeshAgent myAgent;
    private CharacterAnimation playerAnimation;
    void Awake () {
		myRigidbody = GetComponent<Rigidbody>();
		playerAnimation = GetComponent<CharacterAnimation>();
		myAgent = GetComponent<NavMeshAgent>();
		
	} 
	
	public void Movement (Vector3 direction, float speed) {
	
		myRigidbody.MovePosition (myRigidbody.position + (speed * Time.deltaTime * direction.normalized));
	}
	public void Movement (Vector3 direction) {
	
		if (myAgent!=null&&myAgent.isOnNavMesh)
		{
            myAgent.SetDestination(direction);
        }
		
	}

	public void Rotation (Vector3 direction) 
	{
		// rotates the enemy towards the player
		Quaternion newRotation = Quaternion.LookRotation(direction);
		myRigidbody.MoveRotation (newRotation);
	
    }

	public void Die() {
		//myRigidbody.constraints = RigidbodyConstraints.None;
		//myRigidbody.velocity = Vector3.zero;
		//myRigidbody.isKinematic = false;
		//GetComponent<Collider>().enabled = false;
		myRigidbody.isKinematic = true;
		GetComponent<Collider>().enabled = false;
	}

}
