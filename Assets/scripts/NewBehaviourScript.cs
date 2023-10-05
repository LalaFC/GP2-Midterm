using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    public static Color color;
    public Colors colors;

    public MeshRenderer PlayerMesh;
    
    void Start()
    {
        PlayerMesh = GetComponent<MeshRenderer>();
        PlayerMesh.material.color = colors.ColorList[Random.Range(0, colors.ColorList.Count)];
    }
    void OnMouseDown()
    {
        color = colors.ColorList[Random.Range(0, colors.ColorList.Count)];
        PlayerMesh.material.color = color;

        Debug.Log("Player Color Changed");

    }

    public GameObject Canvas;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player Hit. GAME OVER");
            Canvas.SetActive(true);
            SpawnBullet.instance.playerMech.GameOver = true;
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

}
