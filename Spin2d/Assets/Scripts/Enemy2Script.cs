using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    private Transform target;
    public float speed = 5f;
    
    void Start()
    {
        //  StartCoroutine(SelfDestruct());
    }

  
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            
            RotateTowards(target.position);
            MoveTowards(target.position);
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

        
        }
    }
}
