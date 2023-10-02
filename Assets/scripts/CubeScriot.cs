using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public enum objectMovement
{
    Forward,
    Backward,
    Left,
    Right
}
public class CubeScriot : MonoBehaviour
{

    public float  
        speed = 1,
        rangeValue = 7,
        distance;

    public GameObject Enemy;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Enemy.transform.position);

        if (distance <= rangeValue )
        {
            Debug.Log("Point  B has been detected!");
        }
   
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangeValue);
    }

    void Accelerate()
    {
        speed = Mathf.Lerp(1, 100, (Time.time / 100));
    }
}
