using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Bullet_Script : MonoBehaviour
{
    public float bulletspeed = 10f;
    public Rigidbody2D bulletRb;
    public int rotSpeed = 10;

   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletDestroy());
    }
     void Update()
    {
      

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
