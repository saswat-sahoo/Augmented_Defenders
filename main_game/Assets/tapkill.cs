using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class tapkill : MonoBehaviour
{
    private Vector2 touchPosition;
    public Camera arcamera;
    private GameObject zombie;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            if(touch.phase==TouchPhase.Began)
            {
                Ray ray = arcamera.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit))
                {
                    if(hit.transform.tag=="zombie")
                    {
                        zombie = hit.transform.gameObject;
                        zombie.GetComponent<behaviour>().Die();
                    }
                }
            }

        }
    }
}
