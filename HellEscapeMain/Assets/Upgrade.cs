
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
       
        switch (other.tag)
        {
            case "Player":
                PlayerController oyuncu = other.GetComponent<PlayerController>();
                oyuncu.screenController.upgradePanel.SetActive(true);
                oyuncu.Spell(1);
               
                Destroy(gameObject);
                break;
           
        }

    }
}
