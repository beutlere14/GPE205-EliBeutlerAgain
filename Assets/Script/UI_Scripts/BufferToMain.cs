using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class BufferToMain : MonoBehaviour
{

    public GameManager gameManager;
    //scene name we want to open
    public string sceneName = "Main";


    // Start is called before the first frame update
    void Start()
    {
    loadScene();
 
    }

    //To load the main level
    void taskonclick()
    {
  
    }


    //To blank out the autogenerated text
    public void btnValue()
    {

    }


   void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}