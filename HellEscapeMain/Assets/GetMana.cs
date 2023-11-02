
using UnityEngine;

public class GetMana : MonoBehaviour
{
    private ScreenController slider;
    private void Start()
    {
        slider = SharedVariables.Instance.screenCont;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);

            slider.UpdateManaSlider(10);
        }
    }
    void OnBecameInvisible()
    {
        this.gameObject.SetActive(false);
    }
}
