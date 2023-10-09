using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Rotator;

    // Start is called before the first frame update
    void Start()
    {
        Rotator = GameObject.Find("Rotator");
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.SetParent(Rotator.transform, true);

    }
}
