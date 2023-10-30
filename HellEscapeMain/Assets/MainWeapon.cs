
using UnityEngine.InputSystem;
using UnityEngine;

public class MainWeapon :MonoBehaviour
{
    //public float interval = 1.0f;
    public GameObject weapon;
    [SerializeField] private AudioClip shotSound;
    private Animator ani;
    private MyController myController1;
    private InputAction action1;
    float timer;
    public bool attacking;
    private Gamepad gamepad;
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
