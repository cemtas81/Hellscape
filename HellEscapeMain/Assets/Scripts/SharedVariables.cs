
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
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

    public Transform axeAim;
    public CinemachineVirtualCamera cam2;
    public Light sceneLight;
   
   
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
        plyrmvmnt = FindObjectOfType<PlayerMovement>();
        playa = plyrmvmnt.gameObject;
        //Phealth = playa.GetComponent<PlayerHealth>();
        sword = GameObject.FindGameObjectWithTag("boomerang");
        swordIm = sword.GetComponent<MeshRenderer>();
        screenCont = FindObjectOfType<ScreenController>();
        spawner = FindObjectOfType<MySolidSpawner>();
        pool=FindObjectOfType<ObjectPooling2>();
        weaponController = FindObjectOfType<MainWeapon>();
        //audioS = FindObjectOfType<AudioSource>();
        //Effects = playa.GetComponent<AudioSource>();
        //Ammo = GameObject.FindGameObjectWithTag("Spear");
        //astar = FindObjectOfType<AstarSmoothFollow2>();
        //axeAim = GameObject.FindWithTag("Aim").GetComponent<Transform>();
        //attackCam = GameObject.FindGameObjectWithTag("AttackCam");
        //cam2 = attackCam.GetComponent<CinemachineVirtualCamera>();
        //sceneLight = FindObjectOfType<Light>();
        //EffectSlider = GameObject.FindGameObjectWithTag("Effects");
        //musicSlider = GameObject.FindGameObjectWithTag("Music");
       
        //ammoHold = GameObject.FindGameObjectWithTag("AmmoHold").GetComponent<MeshRenderer>();
        //GunShots = GameObject.FindGameObjectWithTag("EnemyGunShots").GetComponent<AudioSource>();
    }
}
