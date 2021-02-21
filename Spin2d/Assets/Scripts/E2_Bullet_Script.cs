using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_Bullet_Script : MonoBehaviour
{
    int bulletspeed = 15;
    public Rigidbody2D bulletRb;
    // Start is called before the first frame update
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
