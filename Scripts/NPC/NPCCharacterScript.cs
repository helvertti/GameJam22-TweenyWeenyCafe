using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
     * @Author Vertti Ahlstén
     */

public class NPCCharacterScript : MonoBehaviour
{
    public string name;
    public GameObject[] sprites;
    public string[] lines;
    public string drink;

    private NPCManager manager;
    private bool active = false, finished = false;
    private float time =5f, timer =0f;

    void Start()
    {
        manager = NPCManager.Instance;
        manager.setClient(name, drink, lines, sprites);
        //manager.generateNPC();

        for (int i = 0; i < sprites.Length; i++) {
            sprites[i].SetActive(false);
        }
    }

    /*
    private void Update()
    {
        if (finished && timer >= time) manager.getCurrentClient().setUsed(true);
        else if (finished) timer += 0.5f;
    }

    private void FixedUpdate()
    {
        if (!active && manager.getCurrentClient().getName().Equals(name))
        {
            active = true;
            sprites[0].SetActive(true);
        }
        else if (active && !string.IsNullOrEmpty(manager.getResult())) {
            if (manager.getResult().Equals("good")) sprites[1].SetActive(true);
            else sprites[2].SetActive(false);

            active = false;
            finished = true;
        }
    }*/
}
