
using UnityEngine;

public class Slasher : MonoBehaviour
{
    GameObject player;
    Vector3 locationInFrontOfPlayer;
    private void Start()
    {
        
        player = SharedVariables.Instance.playa;
        locationInFrontOfPlayer =player.transform.position + player.transform.forward * 10f+Vector3.up*1.5f;
        Destroy(transform.parent.gameObject,0.3f);
    }
    private void Update()
    {
        transform.Rotate( 0, 0, Time.deltaTime * 2000);
        transform.position = Vector3.MoveTowards(transform.position, locationInFrontOfPlayer, Time.deltaTime * 30);
    }

}
