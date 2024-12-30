using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

	private Animator animator;
    private readonly int _attackTrigger = Animator.StringToHash("Attacking");
	private readonly int _runTrigger = Animator.StringToHash("Running");
    private readonly int _velocityZTrigger = Animator.StringToHash("VelocityZ");
    private readonly int _velocityXTrigger = Animator.StringToHash("VelocityX");
	private readonly int _turnTrigger = Animator.StringToHash("Turn");
	private readonly int _dieTrigger = Animator.StringToHash("Die");
    private readonly int _boomTrigger = Animator.StringToHash("Boom");
	private readonly int _unBoomTrigger = Animator.StringToHash("UnBoom");
	private readonly int _playerAttackTrigger = Animator.StringToHash("Attack");
    private readonly int _playerThrowTrigger = Animator.StringToHash("Throw");
    private readonly int _kickTrigger = Animator.StringToHash("Kick");
    void Awake () {

		animator = GetComponent<Animator>();

	}

	public void Attack(bool state)
	{
		animator.SetBool(_attackTrigger, state);
	}
	public void Kicko(bool state)
	{
		animator.SetBool(_kickTrigger,state);
	}
	
	public void Movemento (float value) {

		animator.SetFloat(_runTrigger, value,0.1f,Time.deltaTime);

	}
	public void VelocityZ (float value) {

		animator.SetFloat(_velocityZTrigger, value,0.1f,Time.deltaTime);
      
    }
	public void VelocityX (float value) {

		animator.SetFloat(_velocityXTrigger, value,0.1f,Time.deltaTime);
	
	}
	public void Turning(float value)
	{
		animator.SetFloat(_turnTrigger, value * 2000 * Time.deltaTime);
	}

	public void Die () {

		animator.SetTrigger(_dieTrigger);

	}
	public void Boom () {

		animator.SetTrigger(_boomTrigger);

	}
	public void UnBoom () {

		animator.SetTrigger(_unBoomTrigger);

	}
	public void PlayerAttack()
	{
		animator.SetTrigger(_playerAttackTrigger);
	}
	public void PlayerThrow()
	{
		animator.SetTrigger(_playerThrowTrigger);
	}
}
