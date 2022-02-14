using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicController : MonoBehaviour
{
    private static GameMusicController instance = null;
    public static GameMusicController Instance
    {
        get { return instance; }
    }
    public void Awake()
    {
        if ((instance != null && instance != this) 
            || SceneManager.GetActiveScene().name == "EndingScene") {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
