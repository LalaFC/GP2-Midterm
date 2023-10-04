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
    public Vector3 v3Pos;
    private float spawnCD;
    bool canSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        StartCoroutine(Spawn(spawnCD));

    }
    IEnumerator Spawn(float CD)
    {
        canSpawn = false;
        v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10.0f));
        Instantiate(Enemy, v3Pos, quaternion.identity);
        yield return new WaitForSeconds(2);
        canSpawn=true;

    }

}
