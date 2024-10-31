using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool detected;
    public GameObject Reward;
    private EnemyController enemyController;
    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            detected = true;
            Reward=other.gameObject;
            enemyController.currentState = EnemyController.EnemyState.KickReward;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            detected=false;
            //Reward = null;
            enemyController.currentState = EnemyController.EnemyState.Chasing;
        }
    }
}

