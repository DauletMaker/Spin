using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int bulletspeed = 25;
    public Rigidbody2D bulletRb;
   

    void Start()
    {
        StartCoroutine(BulletDestroy());
    }

   
    
    private void FixedUpdate()
    {
       bulletRb.velocity = (transform.up * bulletspeed);

    }

    public IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
