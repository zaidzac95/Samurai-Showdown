using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMaterialColor : MonoBehaviour
{
    SpriteRenderer sr;

    public Color NewColor = Color.blue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        sr = GetComponent<SpriteRenderer>();

        sr.color = NewColor; 

    }
}
