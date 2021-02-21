using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2SpawnScript : MonoBehaviour
{
    public GameObject Enemy2;
    public GameObject Player;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnNewEnemy2();
        }
    }
    public void SpawnNewEnemy2()
    {
        GameObject a = Instantiate(Enemy2) as GameObject;
        a.transform.position = randomPointOnCircle(Player.transform.position, 15);
        Debug.Log(a.transform.position);


    }
    private Vector3 randomPointOnCircle(Vector3 center, float radius)
    {
        var Vector2 = Random.insideUnitCircle.normalized * radius;
        return center + new Vector3(Vector2.x, Vector2.y, 0);

    }
}
