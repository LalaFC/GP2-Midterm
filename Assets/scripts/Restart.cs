using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void Update()
    {
        
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
