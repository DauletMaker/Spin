using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public float speed = 5f;
    public ParticleSystem DeathParticles;
    public GameObject Ammo_Dropped;
    void Start()
    {
      //  StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Player").transform;
        /*transform.LookAt(target.position);
         transform.Rotate(new Vector3(0, -90, 0), Space.Self);*/
        //transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z);

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
         //   transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
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

            Instantiate(DeathParticles, transform.position, transform.rotation);
            DeathParticles.Play();
            int randNum = Random.Range(0, 10);
            if (randNum >=5 )
            {
                Instantiate(Ammo_Dropped, transform.position, transform.rotation);
            }
           
        }
    }
}
