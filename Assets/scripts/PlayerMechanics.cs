using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
            //distance = Vector3.Distance(transform.position, Enemy.transform.position);
            Vector3 direction = Enemy.transform.position - transform.position;
            float magnitude = direction.magnitude;
            if (magnitude < rangeValue)
            {                
                LookRotation(direction, magnitude);
            }
            else
                inRange = false;
        }

    }
    void LookRotation(Vector3 enemyDirection, float magnitude)
    {
        //SpawnBullet.instance.canShoot = false;
        float rotspeed = 30;

        Vector3 playerDirection = Vector3.forward * magnitude;
        float DirectionAngleDifference = Vector3.Dot(playerDirection, enemyDirection);
        float rotationAngle = Mathf.Acos(DirectionAngleDifference);

        Vector3 directionsCrossProduct = Vector3.Cross(playerDirection, enemyDirection);
        Debug.Log("Cross Product = " + directionsCrossProduct + "\nNormalized = "+directionsCrossProduct.normalized);
        Vector3 rotationAxis = directionsCrossProduct.normalized;

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
