using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWeapon : MonoBehaviour
{

    public GameObject BulletPrefab; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // mouse left click as define by input settings
        {
            GameObject go = Instantiate(BulletPrefab, transform.position, transform.rotation);
            Destroy(go, 10);
        }
    }
}
