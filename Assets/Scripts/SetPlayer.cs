using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    public static void setPlayer(GameObject replacer)
    {
        GameObject Rotator = GameObject.Find("Rotator");

        //Set as a child of rotator
        replacer.transform.SetParent(Rotator.transform, true);

        //Change tag to player
        replacer.tag = "Player";
        
        //Enables Collider
        replacer.GetComponent<CapsuleCollider>().enabled = true;

        //Adds ridibody to player
        replacer.AddComponent<Rigidbody>();
        replacer.GetComponent<Rigidbody>().useGravity = false;

        //Add player to jump script
        replacer.AddComponent<PlayerJump>();

        //Add collide detect script to player
        replacer.AddComponent<CollideDetect>();
    }

    public static void destroyPlayer(GameObject player)
    {
        //Launches player
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(5, 5, 0);
        
        //Removes playerjump script
        Destroy(player.GetComponent<PlayerJump>());

        //Removes player collider
        Destroy(player.GetComponent<CapsuleCollider>());

        //Destroys player after being launched
        Destroy(player, 2.0f);
    }

    public static void moveLine(List<GameObject> crew)
    {
        foreach (GameObject crewM in crew)
        {
            Vector3 goal = crewM.transform.position + new Vector3(0, 0, 2);

            while (true)
            {
                Vector3 start = crewM.transform.position;
                if (start == goal)
                {
                    break;
                }
                crewM.transform.position = Vector3.MoveTowards(start, goal, Time.deltaTime * 2);
            }
        }
    }
}
