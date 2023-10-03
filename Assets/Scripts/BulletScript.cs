using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        /*//Destroys game object after a certain period of time (1 sec)
        Destroy(gameObject, 1.0f);*/
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.z > 75)
        {
            Destroy(gameObject);
        }
    }
}
