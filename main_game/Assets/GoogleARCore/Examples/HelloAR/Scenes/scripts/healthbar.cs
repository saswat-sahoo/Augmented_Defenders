using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    
    public Image fill;
    private barrierHealth barrierHealth;
    private bool found;

    private void Update()
    {
        if (!found)
        {
            barrierHealth = GameObject.FindGameObjectWithTag("barrier").GetComponent<barrierHealth>();
            if (barrierHealth != null)
            {
                found = true;
            }
        }


        if (found)
        {
            Sethealth(barrierHealth.health);
        }
    }



    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
       
    }


    public void Sethealth(float health)
    {
        slider.value = health;
    }
}
