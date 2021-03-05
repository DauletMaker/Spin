using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;

    public GameObject player;

    private float spinSpeed = 0.04f;

    public GameObject bullet;

    public Transform BulletPoint;


    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            player.transform.Rotate(Vector3.forward * 85 * spinSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Rotate(Vector3.forward * -85 * spinSpeed);
        }
    }
}
