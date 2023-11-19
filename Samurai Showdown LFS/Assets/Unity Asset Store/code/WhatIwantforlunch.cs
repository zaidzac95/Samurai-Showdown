using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatIwantforlunch : MonoBehaviour
{
    public string suggestion ;
    public float budget = 100;
    public bool IsLightMeal = false;
    public bool HasMeat = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsLightMeal)
        {
            NewMethod();

        }

        else
        {
            if (budget < 10)
            {

                suggestion = "Yong Tau Foo";

            }

            else if (budget > 10)
            {

                suggestion = "subway";
            }
        }
    }

    private void NewMethod()
    {
        if (HasMeat)
        {
            if (budget > 50)
            {

                suggestion = "T-bone Steak";

            }
            else if (budget < 50)
            {

                suggestion = "Prime Rib";

            }

        }
        else if (!HasMeat)
        {

            if (budget > 30)
            {

                suggestion = "Mala Vegetarian";


            }

            else if (budget < 30)

            {

                suggestion = " Nasi Padang with no meat or fish ";
            }


        }
    }
}
