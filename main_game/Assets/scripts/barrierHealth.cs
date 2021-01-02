using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrierHealth : MonoBehaviour
{
     GameObject zombie;
    private bool underattack;
    public float damage;
    
    public float health = 100f;
    private Collider col;
   

   
  

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        zombie = GameObject.FindGameObjectWithTag("zombie");

        underattack = zombie.GetComponent<behaviour>().isattacking;

       

    }

    // Update is called once per frame
    void Update()
    {
        


        underattack = zombie.GetComponent<behaviour>().isattacking;
        Debug.Log(underattack);
      
         if (underattack)
         {
            StartCoroutine(takeDamage());
               
                Debug.Log(health);
         }


        if (health <= 0f)
        {
            Destroy(GameObject.FindGameObjectWithTag("Finish"));
            col.enabled = false;
            
        }
        else
        {
            return;
        }


    }

   IEnumerator takeDamage()
    {

       
        
           
            yield return new WaitForSeconds(2f);
            health -= damage*Time.deltaTime;
        

        
        
        Debug.Log("takindamage");
    }

    private void OnCollisionEnter(Collision collision)
    {
        zombie = collision.gameObject;
        Debug.Log(collision.gameObject.name);
    }



}
