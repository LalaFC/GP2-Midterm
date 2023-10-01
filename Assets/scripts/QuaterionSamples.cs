using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaterionSamples : MonoBehaviour
{
    //VARIABLES
    public Quaternion Rotation;

    public Vector3 CurrentEulerAngles;
    private float x, y, z;
    public float rotSpeed;

    public Transform TargetA;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation = Quaternion.Euler(90,90,90);

        //Quaternion.identity returns rotation to Quaternion.Euler(0,0,0)
        //transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        //RotationInputs();
        //QuaternionRotateTowards();
        //QuaternionSlerp();
        LookRotation();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;
        //Use Euler angles to show the euler angles of the transformation rotation
        GUI.Label(new Rect(10, 0, 0, 0), "Rotating on X" + x + "Y" + y +"Z" + z, style);
        //Outputs Quaternion.euler angles values
        GUI.Label(new Rect(10, 25, 0, 0), "Current Euler Angles" + CurrentEulerAngles, style);
        //Outputs transform.eulerAngles of the GameObject
        GUI.Label(new Rect(10, 50, 0, 0), "Game Object World Euler Angle" + transform.eulerAngles, style);
    }

    void RotationInputs()
    {
        if (Input.GetKeyDown(KeyCode.X)) { x = 1 - x; }
        if (Input.GetKeyDown(KeyCode.Y)) { y = 1 - y; }
        if (Input.GetKeyDown(KeyCode.Z)) { z = 1 - z; }

        CurrentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotSpeed;
        Rotation.eulerAngles = CurrentEulerAngles;
        transform.rotation = Rotation;
    }

    void QuaternionRotateTowards()
    {
        var step = Time.time * rotSpeed;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetA.rotation, step);
    }

    void QuaternionSlerp()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, TargetA.rotation, Time.time*(Mathf.Lerp(0,rotSpeed,Time.time/1000))/1000);
    }

    void LookRotation()
    {
        Vector3 relativePos = TargetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

}
