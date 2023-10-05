using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMech : MonoBehaviour
{
    float speed;
    MeshRenderer EnemyMesh;
    public UnityEngine.Color color;
    public Colors colors;

    private void Awake()
    {
        color  = colors.ColorList[Random.Range(0, colors.ColorList.Count)];
        EnemyMesh = GetComponent<MeshRenderer>();
        EnemyMesh.material.color = color;
    }

    void Update()
    {
        speed = 1;
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        LookRotation();
    }
    void LookRotation()
    {
        float rotspeed = 20;
        Vector3 relativePos = SpawnBullet.instance.player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotspeed * Time.deltaTime);
    }

}
