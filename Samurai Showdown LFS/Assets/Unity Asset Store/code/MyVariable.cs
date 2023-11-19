using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVariable : MonoBehaviour
{

    public float Radius = 0;

    public float C = 0;

    public float A = 0;
    

    // Start is called before the first frame update
    void Start()
    {


        C = 2 * Mathf.PI * Radius;
        A = Mathf.PI * Mathf.Pow(Radius, 2);


        print("The Circumference of the circle is: " + C + " " + "The Area of the circle is:" + A);


            



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
