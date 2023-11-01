
using DG.Tweening;
using UnityEngine;

public class RewardSword : MonoBehaviour
{
    public Vector3 rotationAngle;
    public float duration;
    private ScreenController screen;
    private void Start()
    {
        screen=SharedVariables.Instance.screenCont;
        transform.DORotate(rotationAngle, duration, RotateMode.FastBeyond360)
           .SetEase(Ease.Linear)
           .SetLoops(-1, LoopType.Incremental);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            screen.NewWeapon();
        }
    }
}
