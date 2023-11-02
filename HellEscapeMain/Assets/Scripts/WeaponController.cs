using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour, IUpgrade {

	[SerializeField] private GameObject projectile;
    [SerializeField] private GameObject Sword;
	[SerializeField] private Transform shootPosition;
	[SerializeField] private AudioClip shotSound;
    private CharacterAnimation playerAnimation;
	public float shootInterval;
    public int Level;
    public MeshRenderer swordImage;
    private void Awake()
    {
        swordImage = Sword.GetComponent<MeshRenderer>();
    }
   
    private void OnEnable()
    {
        
        //swordImage.enabled = true;
        playerAnimation = GetComponentInParent<CharacterAnimation>();
        //StartCoroutine(ShootContinuously());
        playerAnimation.Boom();
    
    }
    public void Upgrade(int level)
    {
        Level += level;
    }
    public void Shoot()
    {
        Instantiate(projectile, shootPosition.position, shootPosition.rotation);
        // plays the shot sound
        AudioController.instance.PlayOneShot(shotSound,0.5f);
    }
    private void OnDisable()
    {

        playerAnimation.UnBoom();
        swordImage.enabled = false;

    }
   
}
