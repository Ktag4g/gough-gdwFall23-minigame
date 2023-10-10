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

        //Add player to jump script
        replacer.AddComponent<PlayerJump>();
    }

    public static void destroyPlayer(GameObject player)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        //Component jumpControls = player.GetComponent<PlayerJump>();

        //Launches player
        rb.velocity = new Vector3(5, 5, 0);

        //Turns off playerJump script
        Destroy(player, 2.0f);
    }
}
