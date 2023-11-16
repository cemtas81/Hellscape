
using UnityEngine.InputSystem;
using UnityEngine;

public class MainWeapon :MonoBehaviour
{
    //public float interval = 1.0f;
    public GameObject weapon, spell1,spell2,spell3,charSkill,skillTree,devilCam;
    [SerializeField] private AudioClip shotSound;
    private Animator ani;
    private MyController myController1;
    private InputAction action1;
    float timer;
    public bool attacking;
    private Gamepad gamepad;
    public KeyCode key;
    
    private void Awake()
    {
      
        myController1 = new MyController();
        ani = GetComponentInParent<Animator>();
    }
    private void Update()
    {
       
        gamepad = Gamepad.current;
        if (Input.GetButton("Fire1")&&!attacking)
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DoSpell1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DoSpell2();
        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DoSpell3();
        } 
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Devilish();
        } 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenCharSkill();
        }
        if (Input.GetKeyDown(key))
        {
            NewSkillTree();
        }

    }
    void Devilish()
    {
        devilCam.SetActive(true);
    }
    void NewSkillTree()
    {

        if (skillTree.activeInHierarchy)
        {
            skillTree.SetActive(false);
          
            Time.timeScale = 1f;
        }
        else
        {
            skillTree.SetActive(true);
            
            Time.timeScale = 0f;
        }

    }

    void OpenCharSkill()
    {
        charSkill.SetActive(!charSkill.activeSelf);
    }
    void DoSpell1()
    {
        if (!spell1.activeInHierarchy)
        {
            spell1.SetActive(true);
        }
       
    }
    void DoSpell2()
    {
        if (!spell2.activeInHierarchy)
        {
            spell2.SetActive(true);
        }
       
    }  
    void DoSpell3()
    {
        if (!spell3.activeInHierarchy)
        {
            spell3.SetActive(true);
        }
       
    }
    void Attack()
    {
        ani.SetTrigger("Attack");
        attacking=true;
        AudioController.instance.PlayOneShot(shotSound);
    }
    private void OnEnable()
    {
        myController1.Enable();
        action1 = myController1.MyGameplay.MoveCursor;
    }
    private void OnDisable()
    {
        myController1.Disable();
    }
    public void Slash()
    {
        _ = Instantiate(weapon, transform.position, transform.rotation);
    }
}
