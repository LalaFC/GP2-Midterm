using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMechanics : MonoBehaviour
{
    public GameObject Enemy;
    public static bool GameOver = false;
    public float
        speed = 1,
        rangeValue = 3,
        distance;
    public bool inRange = false;

    // Update is called once per frame
    void Update()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy != null) 
        {
            distance = Vector3.Distance(transform.position, Enemy.transform.position);
            if (distance < rangeValue)
            {                
                LookRotation();
            }
            else
                inRange = false;
        }

    }
    void LookRotation()
    {
        //SpawnBullet.instance.canShoot = false;
        float rotspeed = 30;
        Vector3 relativePos = Enemy.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotspeed * Time.deltaTime);
        if (transform.rotation == rotation)
        inRange = true;
        //SpawnBullet.instance.canShoot = true;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawSphere(transform.position, rangeValue);
    }

}
