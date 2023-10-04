using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLoco : MonoBehaviour
{
    float speed;
    Vector3 PlayerPos;

    private void Try()
    {
        PlayerPos = EnemySpawner.instance.Player.transform.position;
    }
    void Update()
    {
        LookRotation();
        speed = 1;
        Vector3.MoveTowards( transform.position, PlayerPos, speed);
        //transform.position = Vector3.Lerp(PlayerPos, transform.position, (Time.time / (Vector3.Distance(transform.position, PlayerPos) / speed)));
    }

    void LookRotation()
    {
        Vector3 relativePos = PlayerPos - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation =  rotation;
    }

}
