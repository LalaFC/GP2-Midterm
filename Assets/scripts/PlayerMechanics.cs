using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public static PlayerMechanics instance { get; private set; }

    public GameObject Enemy;
    public float
        speed = 1,
        rangeValue = 3,
        distance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this) { Destroy(this); }
        else { instance = this; }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Enemy.transform.position);
        if (distance < rangeValue)
            LookRotation();
    }
    void LookRotation()
    {
        Vector3 relativePos = transform.position - Enemy.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
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
