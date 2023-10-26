using UnityEngine;

public class ItemMover : MonoBehaviour
{ 
    private Vector3 targetPosition;

    void Update()
    {


        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.y = 0f;
        Move();


    }
    void Move()
    {
        transform.localPosition = targetPosition;
    }

}
