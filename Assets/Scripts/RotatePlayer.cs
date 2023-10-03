using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    private float horizontalInput;
    public float turnSpeed = 120.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get player input
        horizontalInput = Input.GetAxis("Horizontal");

        //Rotate player
        transform.Rotate(Vector3.back, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
