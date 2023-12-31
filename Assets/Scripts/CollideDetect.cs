using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDetect : MonoBehaviour
{
    private bool collisionOccured = false;

    public Rigidbody rb;
    public GameObject sp;
    public SpawnManager spawnManager;
    private SetPlayer SetPlayer;

    void Start()
    {
        //Resets bear physics
        rb = GetComponent<Rigidbody>();
        rb.inertiaTensor = new Vector3(1, 1, 1);

        //Sets Spawn manager
        sp = GameObject.Find("Spawn Manager");
        spawnManager = sp.GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Checks to see if collision has already haappened
        if (collisionOccured == false)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                if (SpawnManager.crew.Count > 0)
                {
                    //Knocks off a bear when hit by an asteroid
                    ScoreManager.BearCounter = ScoreManager.BearCounter - 1;
                    Debug.Log("Crewmate Counter: " + (ScoreManager.BearCounter - 1));

                     //Destroys old player
                    SetPlayer.destroyPlayer(gameObject);

                    //Moves all bears forward in line
                    SetPlayer.moveLine(SpawnManager.crew);

                    //Sets next player as bear
                    SetPlayer.setPlayer(SpawnManager.crew[0]);

                    //Removes new player from crew list
                    SpawnManager.crew.RemoveAt(0);

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
                Debug.Log("Crewmate Counter: " + (ScoreManager.BearCounter - 1));

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
