using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1ScriptSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy1;
    public GameObject Player;
    public float respawnTime;
    
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
            SpawnNewEnemy1();
        }
    }
    public void SpawnNewEnemy1()
    {
        GameObject a = Instantiate(Enemy1) as GameObject;
        a.transform.position = randomPointOnCircle(Player.transform.position, 15);
        Debug.Log(a.transform.position);


    }
    private Vector3 randomPointOnCircle(Vector3 center, float radius)
    {
        var Vector2 = Random.insideUnitCircle.normalized * radius;
        return center + new Vector3(Vector2.x, Vector2.y, 0);

    }

}
