using UnityEngine;
namespace cemtas81
{
    public class SpawnPointController : MonoBehaviour
    {
        public Transform[] spawnPoints; // Assign your spawn points in the Inspector
        public GameObject player; // Reference to the player GameObject
   

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    // Enable the spawn point
                    spawnPoint.gameObject.SetActive(true);
                   
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == player)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    // Disable the spawn point
                    spawnPoint.gameObject.SetActive(false);
                }
            }
        }
    }


}
