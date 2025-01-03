
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public enum PrefabType
{
    Prefab0 = 0,
    Prefab1 = 1,
    Prefab2 = 2,
    Prefab3 = 3,
    Prefab4 = 4,
    Prefab5 = 5,
    Prefab6 = 6,
    Prefab7 = 7
}
public class SharedVariables : MonoBehaviour
{
    private static SharedVariables instance;
    public static SharedVariables Instance { get { return instance; } }
    public ObjectPooling2 pool;
    public PlayerMovement plyrmvmnt;
    public GameObject playa, sword, Ammo, attackCam;
    //public PlayerHealth Phealth;
    public MeshRenderer swordIm;
    public ScreenController screenCont;
    public MySolidSpawner spawner;
    
    public MainWeapon weaponController;
    public AudioSource audioS, Effects, GunShots;
    public CrackCam crackCam;
    public Transform axeAim;
    public CinemachineVirtualCamera cam2;
    public Light sceneLight;
    public Camera cam;
   
    public GameObject EffectSlider, musicSlider;
 
    public MeshRenderer ammoHold;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
       

    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadScene(4);
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RefreshVariables();
    }
    public void RefreshVariables()
    {
        plyrmvmnt = FindFirstObjectByType<PlayerMovement>();
        playa = plyrmvmnt.gameObject;
        //Phealth = playa.GetComponent<PlayerHealth>();
        sword = GameObject.FindGameObjectWithTag("boomerang");
        swordIm = sword.GetComponent<MeshRenderer>();
        screenCont = FindFirstObjectByType<ScreenController>();
        spawner = FindFirstObjectByType<MySolidSpawner>();
        pool =FindFirstObjectByType<ObjectPooling2>();
        weaponController = FindFirstObjectByType<MainWeapon>();
        crackCam = FindFirstObjectByType<CrackCam>();
        //audioS = FindObjectOfType<AudioSource>();
        //Effects = playa.GetComponent<AudioSource>();
        //Ammo = GameObject.FindGameObjectWithTag("Spear");
        //astar = FindObjectOfType<AstarSmoothFollow2>();
        axeAim = GameObject.FindWithTag("Aim").GetComponent<Transform>();
        //attackCam = GameObject.FindGameObjectWithTag("AttackCam");
        //cam2 = attackCam.GetComponent<CinemachineVirtualCamera>();
        //sceneLight = FindObjectOfType<Light>();
        //EffectSlider = GameObject.FindGameObjectWithTag("Effects");
        //musicSlider = GameObject.FindGameObjectWithTag("Music");
        cam = Camera.main;
        //ammoHold = GameObject.FindGameObjectWithTag("AmmoHold").GetComponent<MeshRenderer>();
        //GunShots = GameObject.FindGameObjectWithTag("EnemyGunShots").GetComponent<AudioSource>();
    }

}
