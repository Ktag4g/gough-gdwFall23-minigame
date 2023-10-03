using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public Transform spawn;

    public GameObject[] bullets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        shoot();
    }

    private void move()
    {
        //Old Movement:
        //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"),  // x axis     GetAxisRaw prevents slow-in , slow-out
                                          Input.GetAxis("Vertical"),    // y axis
                                          0.0f);                        // z axis
        transform.Translate(inputVector.normalized * speed * Time.deltaTime); // .normailized prevents speeding up when diagonal
    }

    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Old Shooting
            //Instantiate(bulletPrefab, spawn.position, bulletPrefab.transform.rotation);
            
            int whichBullet = Random.Range(0, bullets.Length);
            Instantiate(bullets[whichBullet], spawn.position, bullets[whichBullet].transform.rotation);
        }
    }
}
