

using UnityEngine;

public class MainWeapon :MonoBehaviour
{
    //public float interval = 1.0f;
    public GameObject weapon;
   
  
    public void Slash()
    {
        _ = Instantiate(weapon, transform.position, transform.rotation);
    }
}
