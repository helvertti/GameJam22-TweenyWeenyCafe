using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScreenClick : MonoBehaviour
{

    private ResultsManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = ResultsManager.Instance;   
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            LoaderScript.Load(LoaderScript.Scene.StartMenuScene);
        }
    }

    public void onClick(GameObject img) {
        Debug.Log(img);
        img.SetActive(false);
    }

    public void endGame() {
        Application.Quit();
    }

    void OnMouseDown() {
        endGame();
    }
}
