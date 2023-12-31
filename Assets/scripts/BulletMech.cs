using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class BulletMech : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody rb;
    public float force = 5;
    public Vector3 direction;
    private MeshRenderer BulletMesh;

    // Start is called before the first frame update
    private void Awake()
    {
        BulletMesh = GetComponent<MeshRenderer>();
        BulletMesh.material.color = NewBehaviourScript.color;
        if (SpawnBullet.instance.playerMech.Enemy != null)
        enemy = SpawnBullet.instance.playerMech.Enemy;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (SpawnBullet.instance.playerMech.inRange == false)
            direction = SpawnBullet.instance.LastDirection;
        else
        {
            direction = enemy.transform.position - transform.position;
            SpawnBullet.instance.LastDirection = direction;
        }

        rb.velocity = new Vector3(direction.x, direction.y, direction.z).normalized * force;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position,SpawnBullet.instance.player.transform.position)>SpawnBullet.instance.playerMech.rangeValue)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Color bulletColor, enemyColor;
            bulletColor = this.GetComponent<MeshRenderer>().material.color;
            enemyColor = collision.gameObject.GetComponent<MeshRenderer>().material.color;

            if (bulletColor == enemyColor)
            {
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}
