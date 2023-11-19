using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLightColor : MonoBehaviour



{
    public Color MyColor = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Light cc = GetComponent<Light>();

        cc.color = MyColor;




    }
}
