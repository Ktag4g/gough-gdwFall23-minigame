using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect : MonoBehaviour
{
    private int BearCounter = 0;
    private bool collisionOccured = false;

    public Rigidbody rb;

    GameObject Player;
    void Start()
    {
        //Finding Player gameobject by name
        Player = GameObject.Find("Player");

        //Resets bear physics
        rb = GetComponent<Rigidbody>();
        rb.inertiaTensor = new Vector3(1, 1, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks to see if collision has already haappened
        if (collisionOccured == false)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                if (BearCounter > 0)
                {
                    //Knocks off a bear when hit by an asteroid
                    BearCounter = BearCounter - 1;
                    Debug.Log("Bear Counter: " + BearCounter);

                    //Confirms collision
                    collisionOccured = true;
                }
                else
                {
                    //Ends the game when out of bears
                    Debug.Log("Game Over!");

                    //Launches bear
                    rb.velocity = new Vector3(3, 3, 0);
                    
                    //Confirms collision
                    collisionOccured = true;
                }
            }
            else if (other.gameObject.tag == "Bear")
            {
                //Resets bear physics
                rb.velocity = new Vector3(0, 0, 0);
                rb.angularVelocity = new Vector3(0, 0, 0);

                //Collects bear, updates score
                Destroy(other.gameObject);
                BearCounter = BearCounter + 1;
                Debug.Log("Bear Counter: " + BearCounter);

                //Confirms collision
                collisionOccured = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collisionOccured = false;
    }


}
