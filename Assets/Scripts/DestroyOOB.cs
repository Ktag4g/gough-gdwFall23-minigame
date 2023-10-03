using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Destroys after offscreen
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
