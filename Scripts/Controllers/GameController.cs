using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    /*
     * @Author Vertti Ahlstén
     */

public class GameController
{
    private static GameController instance;

    private GameMusicController musicController;
    private NPCManager npcManager;

    private bool firstTime;
    private int rounds;

    public static GameController Instance
    {
        get
        {
            if (instance == null) instance = new GameController();
            return instance;
        }
    }



    private GameController() {
        npcManager = NPCManager.Instance;
        musicController = GameMusicController.Instance;

        firstTime = true;
        rounds = 0;
    }

    public bool getFirstTime() { return firstTime; }

    public void generateClient() {
        firstTime = false;
        rounds++;

        npcManager.generateNPC();
    }

    public bool gameOngoing() {
        if (rounds >= 5) {
            return false;
        }
        return true;
    }

    public bool isCurrentNpcNull() {
        return npcManager.getCurrentClient() == null;
    }

    public void setCurrentNull() { npcManager.setCurrentNull(); }

    public NPCCharacter getCurrentNPC() { return npcManager.getCurrentClient(); }

}
