
using UnityEngine;

public class Slicer2 : MonoBehaviour,IUpgrade
{
    public Transform player;
    public float speed;
    public int Level=1;
    public void Upgrade(int level)
    {
        Level += level;
    }
    void Update()
    {
        transform.position = new Vector3(player.position.x,player.position.y+1.5f,player.position.z);
        transform.Rotate(Level*speed * Time.deltaTime * Vector3.up);
              
    }
  
}
