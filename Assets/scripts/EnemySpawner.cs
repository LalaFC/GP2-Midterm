using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Player;

    public Vector3 SpawnSpot,
                   MinDist;
    public List<Vector3> possibleSpots;
    private float spawnCD = 10;
    bool canSpawn = true;


    private void Awake()
    {
        float range = Player.GetComponent<PlayerMechanics>().rangeValue;

        //MinDist = UnityEngine.Random.onUnitSphere + new Vector3(1,1,1)*(range);
        Vector3 RandomPoint = UnityEngine.Random.onUnitSphere;
        possibleSpots.Add(RandomPoint + new Vector3(-1, 1, 1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(1, -1, 1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(1, 1, -1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(1, 1, 1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(-1, -1, -1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(-1, -1, 1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(-1, 1, -1) * (range));
        possibleSpots.Add(RandomPoint + new Vector3(1, -1, -1) * (range));

    }
    // Update is called once per frame
    void Update()
    {

        MinDist = possibleSpots[UnityEngine.Random.Range(0, possibleSpots.Count)];
        float spawnAccelerator=1;
        if (Time.time >= 60)
            spawnAccelerator = 2;
        spawnCD = math.lerp(10, 3, (spawnAccelerator * Time.deltaTime) / 100);
        if (canSpawn)
        StartCoroutine(Spawn(spawnCD));
        if (PlayerMechanics.GameOver == true)
            StopCoroutine(Spawn(spawnCD));

    }
    IEnumerator Spawn(float CD)
    {

        canSpawn = false;
        SpawnSpot = new Vector3(UnityEngine.Random.Range(MinDist.x, MinDist.x + 2),
                                UnityEngine.Random.Range(MinDist.y, MinDist.y + 2),
                                UnityEngine.Random.Range(MinDist.z, MinDist.z + 2));

        Instantiate(Enemy, SpawnSpot, LookRotation());
        yield return new WaitForSeconds(CD);
        canSpawn=true;
    }

    Quaternion LookRotation()
    {
        Vector3 relativePos = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        return rotation;
    }


}
