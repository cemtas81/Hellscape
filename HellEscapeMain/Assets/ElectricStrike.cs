using System.Collections;
using UnityEngine;

public class ElectricStrike : MonoBehaviour,IUpgrade
{
    public GameObject targetObject;
    public float activeDuration = 5.0f;
    public float inactiveDuration = 5.0f;
    public Transform player;
    public int Level;
    
    private void OnEnable()
    {
        if (SharedVariables.Instance.screenCont.manaSlider.value>=30)
        {
            Spell1();
        }
        else
        {
            Debug.Log("bitti");
        }
        SharedVariables.Instance.screenCont.UpdateManaSlider(-30);   
    }
    public void Upgrade(int level)
    {
       Level += level;
    }
    //private void OnEnable()
    //{
    //    StartCoroutine(ActivateObject2());
       
    //}

    //private IEnumerator ActivateObject2()
    //{
    //    while (true)
    //    {

    //        targetObject.transform.SetPositionAndRotation(new Vector3(player.position.x, targetObject.transform.position.y, player.position.z + 3.5f), player.rotation);
    //        targetObject.SetActive(true);
    //        yield return new WaitForSeconds(activeDuration);
    //        targetObject.SetActive(false);
    //        yield return new WaitForSeconds(inactiveDuration);
    //    }
    //}
    public void Spell1()
    {
        if (!targetObject.activeInHierarchy)
        {
            targetObject.transform.SetPositionAndRotation(new Vector3(player.position.x, targetObject.transform.position.y, player.position.z + 3.5f), player.rotation);
            targetObject.SetActive(true);
            StartCoroutine(Dissolve());
        }
        
    }
    IEnumerator Dissolve()
    {
        while (true)
        {
            yield return new WaitForSeconds(activeDuration);
            targetObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    
}

