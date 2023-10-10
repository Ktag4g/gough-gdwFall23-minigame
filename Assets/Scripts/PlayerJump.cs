using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            if (transform.localPosition.y > 2.5)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
        }
    }
}
