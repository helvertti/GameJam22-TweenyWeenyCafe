using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* 
 * @Author Vertti Ahlstén
 */

public class StartMenuButtons : MonoBehaviour
{
    public bool isStart, isQuit;

    private GameController gameController;

    private void Start()
    {
        gameController = GameController.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }
    }

    public void sceneChanger()
    {
        if (isStart)
        {
            LoaderScript.Load(LoaderScript.Scene.RestaurantScene);
        }
        else if (isQuit)
        {
            Application.Quit();
        }
    }
}
