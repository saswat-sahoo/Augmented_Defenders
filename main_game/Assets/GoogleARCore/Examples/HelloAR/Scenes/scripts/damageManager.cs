using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageManager : MonoBehaviour
{

    public GameObject[] zombies;
    private new GameObject collider;
   public float damage;
    private bool found;


    // Start is called before the first frame update

   
    // Update is called once per frame
    void Update()
    {
        if(!found)
        {
            collider = GameObject.FindGameObjectWithTag("barrier");
            collider.GetComponent<barrierHealth>().damage = damage;
            if(collider!=null)
            {
                found = true;
            }

        }

        zombies = GameObject.FindGameObjectsWithTag("zombie");
        if (zombies.Length == 1)
        {
            collider.GetComponent<barrierHealth>().damage = damage;
        }
        if (zombies.Length!=0)
        {
            
            if (collider.GetComponent<barrierHealth>().damage != collider.GetComponent<barrierHealth>().damage * (zombies.Length))
            {
                collider.GetComponent<barrierHealth>().damage = damage * (zombies.Length);
              
            }
        }
     

 
      else
        {

            collider.GetComponent<barrierHealth>().damage = damage;

            return;
        }
    }
}
