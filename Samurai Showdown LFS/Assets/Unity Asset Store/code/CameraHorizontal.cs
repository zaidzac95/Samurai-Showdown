using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHorizontal : MonoBehaviour
{

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the camera's new position
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

}
