using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class SceneControllerScript : MonoBehaviour
{
    private GameController gameController;
    private NPCCharacter current;
    private bool finished;
    private float time = 5f, timer = 0f;

    void Start()
    {
        gameController = GameController.Instance;
        if (gameController.getFirstTime())
        {
            gameController.generateClient();
        }
        finished = false;
    }

    private void FixedUpdate()
    {

        if (!gameController.isCurrentNpcNull() || current != null)
        {
            current = gameController.getCurrentNPC();
            GameObject[] sprites = current.getSprites();
            sprites[0].SetActive(true);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);
        }

        if (finished && timer >= time)
        {
            current = gameController.getCurrentNPC();
            GameObject[] sprites = current.getSprites();
            sprites[0].SetActive(false);
            sprites[1].SetActive(false);
            sprites[2].SetActive(false);

            gameController.setCurrentNull();
            finished = false;
            timer = 0f;
        }else if (finished) {
            current = gameController.getCurrentNPC();
            GameObject[] sprites = current.getSprites();

            sprites[0].SetActive(false);

            if (current.getResult() == "good") sprites[1].SetActive(true);
            else sprites[2].SetActive(true);

            timer += 0.1f;
        } else if (!(current.getResult() == null || current.getResult() == "") && !finished ) {
            current = gameController.getCurrentNPC();
            GameObject[] sprites = current.getSprites();
            sprites[0].SetActive(false);
            finished = true;
        }
        
        if (gameController.getCurrentNPC() == null)
        {
            if (gameController.gameOngoing()) {
                gameController.generateClient();
            } else {
                LoaderScript.Load(LoaderScript.Scene.EndingScene);
            }
        }
    }
}
