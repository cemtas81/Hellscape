using UnityEngine;
using DG.Tweening;

public class Mining : MonoBehaviour
{
    public float scaleAmount = 1.5f; // The amount to scale the object
    public float scaleDuration = 0.3f; // The duration of the scaling effect
    private MySolidSpawner Parent;
    private int hitCount;
    private void Start()
    {
        Parent=SharedVariables.Instance.spawner;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Sword"))
        {
            hitCount++;
            if (hitCount>9)
            {
                Destroy(gameObject);
                return;
            }
            Parent.Spawn3(this.transform.position);
            // Scale up
            transform.DOScale(1 * scaleAmount, scaleDuration)
            // Once the scaling up is complete, scale down to the original scale
            .OnComplete(() => transform.DOScale(1, scaleDuration));
        }
    }
}
