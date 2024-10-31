using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool detected;
    public GameObject Reward;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            detected = true;
            Reward=other.gameObject;    
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Reward"))
        {
            detected=false;
            Reward = null;
        }
    }
}

