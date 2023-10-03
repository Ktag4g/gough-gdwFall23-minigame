using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect : MonoBehaviour
{
    private int BearCounter = 0;

    public Rigidbody rb;

    GameObject Player;
    void Start()
    {
        //Finding Player gameobject by name
        Player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody>();

        rb.inertiaTensor = new Vector3(1, 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (BearCounter > 0)
            {
                BearCounter = BearCounter - 1;
                Debug.Log("Bear Counter: " + BearCounter);
            }
            else
            {
                Debug.Log("Game Over!");

                rb.velocity = new Vector3(3, 3, 0);
            }
        }
        else if (other.gameObject.tag == "Bear")
        {
            Destroy(other.gameObject);
            BearCounter = BearCounter + 1;
            Debug.Log("Bear Counter: " + BearCounter);
        }
    }
}
