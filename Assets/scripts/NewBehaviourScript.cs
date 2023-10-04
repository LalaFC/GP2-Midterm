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
<<<<<<< Updated upstream
    public MeshRenderer PlayerColor;
    private MeshRenderer bulletcolor;
    bool canChange = true;
=======
    public MeshRenderer meshRend;
    private bool canChange = false;
>>>>>>> Stashed changes
  
    // Start is called before the first frame update
    void Start()
    {
        PlayerColor = GetComponent<MeshRenderer>();
        bulletcolor = GetComponentInChildren<MeshRenderer>();

<<<<<<< Updated upstream
=======
    // Update is called once per frame
    void Update()
    {
        if (canChange == true)
        {
          //  StartCoroutine(changeColor());

        }
        color = colors[Random.Range(0, colors.Count)];
>>>>>>> Stashed changes
    }

    private void OnMouseDown()
    {
<<<<<<< Updated upstream
        color = colors[Random.Range(0, colors.Count)];
        PlayerColor.material.color = color;

=======
        meshRend.material.color = color;
        Debug.Log("mouse entered");
>>>>>>> Stashed changes
    }

    private void OnMouseEnter()
    {
<<<<<<< Updated upstream
        PlayerColor.material.color = Color.black;
=======
        meshRend.material.color = Color.black;
        Debug.Log("mouse entered");
>>>>>>> Stashed changes
    }
    private void OnMouseExit()
    {
        PlayerColor.material.color = Color.red;
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
        PlayerColor.material.color = color;
        
        yield return new WaitForSeconds(2);
        canChange = true;
    }
}
