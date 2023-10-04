using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject player;
    private Color color;
    public List<Color> colors;

    public MeshRenderer PlayerMesh;
    private MeshRenderer BulletMesh;


    public MeshRenderer meshRend;


    void Start()
    {
        PlayerMesh = GetComponent<MeshRenderer>();
        BulletMesh = GetComponentInChildren<MeshRenderer>();

    }
    void OnMouseDown()
    {

        color = colors[Random.Range(0, colors.Count)];
        PlayerMesh.material.color = color;

        Debug.Log("Player Color Changed");

    }

}
