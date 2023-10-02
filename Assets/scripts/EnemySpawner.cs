using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.5f, 10.0f));
        Instantiate(Enemy, v3Pos, LookRotation());
        yield return new WaitForSeconds(2);
    }
    private quaternion LookRotation()
    {
        Vector3 relativePos = transform.position - Player.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        return rotation;
    }
}
