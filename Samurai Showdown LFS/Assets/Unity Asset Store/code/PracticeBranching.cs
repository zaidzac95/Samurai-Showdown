using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBranching : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            print("Q is press");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            print("Q is depressed");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            print("Q is release");

        }

        if (Input.anyKey == false)
        {
            print("no key is pressed");

        }

    }
}
