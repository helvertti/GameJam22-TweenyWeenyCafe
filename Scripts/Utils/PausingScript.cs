using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingScript : MonoBehaviour {
    private bool isPaused;
    public GameObject PauseMenu;

    void Start() {
        PauseMenu.SetActive(isPaused);
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            PauseGame();
        }
    }

    void PauseGame() {
        if (isPaused) {
            Time.timeScale = 0f;
            PauseMenu.SetActive(isPaused);
        } else {
            Time.timeScale = 1;
            PauseMenu.SetActive(isPaused);
        }
    }

    public void Resume() {
        isPaused = !isPaused;
        PauseGame();
    }

    public void Quit() {
        Debug.Log("pressed quit game button. quitting application");
        Application.Quit();
    }
}
