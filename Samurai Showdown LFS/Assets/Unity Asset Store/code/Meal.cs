using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MyMeal
{

    Breakfast,
    Lunch,
    Dinner,
    Supper


}


public class Meal : MonoBehaviour

{


    public MyMeal Food;
    // Start is called before the first frame update
    void Start()
    {
        // if (Food == MyMeal.Breakfast)
        // {

        //  print("Egg With Toast");


        // }
        // else if (Food == MyMeal.Lunch)
        // {
        //  print("Nasi Goreng");

        // }
        // else if (Food == MyMeal.Dinner)
        //  {

        //  print("Arnold Fried Chicken");

        // }
        //  else if (Food == MyMeal.Supper)
        // {
        //   print("Tea"); 
        //  }



        switch (Food)

        {

            case MyMeal.Breakfast:
                print("Egg With Toast");
                break;
            case MyMeal.Lunch:
                print("Nasi Goreng");
                break;
            case MyMeal.Dinner:
                print("Arnold Chicken");
                break;
            case MyMeal.Supper:
                print("Tea");
                break;

        }

        // Update is called once per frame
 
    }


    void Update()
    {

    }
}
