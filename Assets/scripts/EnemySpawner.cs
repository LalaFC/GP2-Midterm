using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance { get; private set; }
    public GameObject Enemy;
    public GameObject Player;

    public Vector3 SpawnSpot,
                   MinDist;

    private float spawnCD;
    bool canSpawn = true;


    private void Start()
    {
        float range = Player.GetComponent<PlayerMechanics>().rangeValue;
        MinDist = new Vector3(  (Player.transform.position.x + range + 0.5f),
                                (Player.transform.position.y + range + 0.5f),
                                (Player.transform.position.z + range + 0.5f) );
    }
    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        StartCoroutine(Spawn(spawnCD));

    }
    IEnumerator Spawn(float CD)
    {

        canSpawn = false;
        SpawnSpot = new Vector3(UnityEngine.Random.Range(MinDist.x, MinDist.x + 2),
                                UnityEngine.Random.Range(MinDist.y, MinDist.y + 2),
                                UnityEngine.Random.Range(MinDist.z, MinDist.z + 2));
        Instantiate(Enemy, SpawnSpot, quaternion.identity);
        yield return new WaitForSeconds(2);
        canSpawn=true;

    }

}
