using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject cube;
    private Color color;
    public List<Color> colors;
    public MeshRenderer meshRend;
    private bool canChange = true;
  
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canChange == true)
        {
            StartCoroutine(changeColor());

        }
    }

    private void OnEnable()
    {
        color = colors[Random.Range(0, colors.Count)];
        meshRend.material.color = color;
    }
    private void OnDisable()
    {
        
    }


    private void OnMouseDown()
    {
        meshRend.material.color = Color.green;
    }

    private void OnMouseEnter()
    {
        meshRend.material.color = Color.black;
    }
    private void OnMouseExit()
    {
        meshRend.material.color = Color.red;
    }

    /*private void OnMouseOver()
    {
        Vector3 screenPos;
        Vector3 worldPos;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        if (plane.Raycast(ray, out float distance))
        {
            worldPos = ray.GetPoint(distance);
        }
        transform.position = worldPos;
    }
    private void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cube.transform.position.z);
        cube.transform.position = mousePosition;
    }*/
    IEnumerator changeColor()
    {

            canChange = false;
            color = colors[Random.Range(0, colors.Count)];
            meshRend.material.color = color;
        
        yield return new WaitForSeconds(2);
        canChange = true;
    }
}
