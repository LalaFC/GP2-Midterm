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
        speed=1,
        rangeValue = 3,
        distance;
    public objectMovement cubeMovement;
    public Transform pointA, pointB;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, pointB.position);

        if (Input.GetKeyDown(KeyCode.W))
            cubeMovement = objectMovement.Forward;
        else if (Input.GetKeyDown(KeyCode.A))
            cubeMovement = objectMovement.Backward;
        else if (Input.GetKeyDown(KeyCode.S))
            cubeMovement = objectMovement.Left;
        else if (Input.GetKeyDown(KeyCode.D))
            cubeMovement = objectMovement.Right;

       /* switch (cubeMovement)
        {
            case objectMovement.Forward:
                moveForward();
                break;
            case objectMovement.Backward:
                moveBackward();
                break;
            case objectMovement.Left:
                moveLeftward();
                break;
            case objectMovement.Right:
                moveRightward();
                break;
            default:
                break;
        }*/

        //transform.position = Vector3.Lerp(transform.position, pointB.position, speed * Time.deltaTime).normalized;
        //transform.position = Vector3.Lerp(pointA.position, pointB.position, (Time.time / (Vector3.Distance(pointA.position, pointB.position) / speed)));

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
    void moveForward()
    {
        transform.position = (transform.position+Vector3.forward) * speed * Time.time;
    }
    void moveBackward()
    {
        transform.position = (transform.position + Vector3.back) * speed * Time.time;
    }
    void moveLeftward()
    {
        transform.position = Vector3.left * speed * Time.time;
    }
    void moveRightward()
    {
        transform.position = Vector3.right * speed * Time.time;
    }


    void Accelerate()
    {
        speed = Mathf.Lerp(1, 100, (Time.time / 100));
    }
}
