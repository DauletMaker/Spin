using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    private Transform target;
    public float speed = 3f;
    public Transform E2_bullet_point;
    public GameObject E2bullet;
    public float timestamp = 1f;

    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float visualTime = 0.0f;

    public ParticleSystem DeathParticles;
    public GameObject Ammo_Dropped;

    void Start()
    {
        //  StartCoroutine(SelfDestruct());
      
    }

  
    void Update()
    {
       
        target = GameObject.FindWithTag("Player").transform;

        if (Vector3.Distance(transform.position, target.position) > 5f)
        {
            speed = 3f;
            RotateTowards(target.position);
            MoveTowards(target.position);

        }
        else if (Vector3.Distance(transform.position, target.position) <= 5f)
        {
           
            RotateTowards(target.position);
            speed = 0f;
            timer += Time.deltaTime;    
            
            if (timer > waitTime)   //condition to spawn Enemy2 bullet every 1 second.
            {
                visualTime = timer;

                // Remove the recorded 1 second.           
                timer = timer - waitTime;
                StartCoroutine(E2_Shooting());
            }
        }
    }
    private void RotateTowards(Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    private void MoveTowards(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Instantiate(DeathParticles, transform.position, transform.rotation);

            int randNum = Random.Range(0, 10);
            if (randNum >= 5)
            {
                Instantiate(Ammo_Dropped, transform.position, transform.rotation);
            }
        }
    }
    
    IEnumerator E2_Shooting()
    {
        
            Instantiate(E2bullet, E2_bullet_point.transform.position, E2_bullet_point.transform.rotation);
            yield return new WaitForSeconds(1f);
        
           
        
        

    }

        
    
}
