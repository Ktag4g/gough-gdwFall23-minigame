using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect : MonoBehaviour
{
    private bool collisionOccured = false;

    public Rigidbody rb;
    public SpawnManager spawnManager;
    public SetPlayer SetPlayer;

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
                if (ScoreManager.BearCounter > 0)
                {
                    //Knocks off a bear when hit by an asteroid
                    ScoreManager.BearCounter = ScoreManager.BearCounter - 1;
                    Debug.Log("Bear Counter: " + ScoreManager.BearCounter);

                    SetPlayer.destroyPlayer(gameObject);

                    //Confirms collision
                    collisionOccured = true;
                }
                else
                {
                    //Ends the game when out of bears
                    Debug.Log("Game Over!");

                    //Launches bear
                    SetPlayer.destroyPlayer(gameObject);

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
                ScoreManager.BearCounter = ScoreManager.BearCounter + 1;
                Debug.Log("Bear Counter: " + ScoreManager.BearCounter);

                //Spawns crew bear
                spawnManager.SpawnCrewBear();

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
