using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject BulletPoint;
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(bullet, BulletPoint.transform.position, BulletPoint.transform.rotation);
            Debug.Log("tRUBI");

            rb.AddForce(transform.up * 1000f);
        }
    }
}
