using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoco : MonoBehaviour
{
    float speed;
    public GameObject Player;
    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Lerp(0.01f, 3, Time.time / 100);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
    }
}
