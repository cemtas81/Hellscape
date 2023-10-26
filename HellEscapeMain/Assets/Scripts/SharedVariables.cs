
using UnityEngine;

public class SharedVariables : MonoBehaviour
{
    public static PlayerController Playa;
    public static MySolidSpawner Spawner;
    public static ScreenController screenController_m;
    public static GameObject hero;
    public static MeshRenderer Sword;
    private void Awake()
    {
        Playa=FindObjectOfType<PlayerController>();
        Spawner=FindObjectOfType<MySolidSpawner>();
        screenController_m=FindObjectOfType<ScreenController>();
        hero=Playa.gameObject; 
        Sword= GameObject.FindGameObjectWithTag("boomerang").GetComponent<MeshRenderer>();
    }
}
