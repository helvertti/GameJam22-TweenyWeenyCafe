using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* @Author Vertti Ahlstén
* @Author ikylios 
*/

public class NPCScript : MonoBehaviour
{
    public Text textKupla;
    public Text nimiKupla;
    public GameObject background;

    private bool active, clicked;
    private float timer;
    private char[] letters;
    private int index, lineRound;
    private string tempLine;

    private string[] line;
    private string nimi;
    private GameObject[] sprites;

    private NPCManager npcManager;
    private NPCCharacter npc = null;

    private void Start()
    {
        npcManager = NPCManager.Instance;

        /* 
         * First line is converted to letters.
         * TextFields are reseted to empty.
         * Background sprite is set deactive.
         * Sprites are reseted until further call.
         * Active calling is set not activated.
         * Variables has been set.
         */

        textKupla.text = "";
        nimiKupla.text = "";
        background.SetActive(false);
        active = false;
        timer = 0f; index = 0; lineRound = 0;
        tempLine = "";
    }

    private void Update()
    {
        if (active && Time.timeScale != 0f)
        {
            nimiKupla.text = nimi;
            background.SetActive(true);

            timer -= 0.2f;
            if (timer <= 0 && index < letters.Length)
            {
                timer += 1f;
                tempLine += letters[index];
                textKupla.text = tempLine;
                index += 1;
            }
            else if ((Input.GetKeyDown("space") || clicked ) && index >= letters.Length)
            {
                lineRound += 1;
                clicked = false;

                if (lineRound < line.Length && !string.IsNullOrEmpty(line[lineRound]))
                {
                    textKupla.text = "";
                    nimiKupla.text = "";

                    index = 0;
                    tempLine = null;
                    letters = null;
                    letters = line[lineRound].ToCharArray();
                    timer += 1f;
                }
                else if (lineRound >= line.Length && npcManager.getResult() == null) {
                    LoaderScript.Load(LoaderScript.Scene.PotionMixScene);
                }
                else if (lineRound >= line.Length && npcManager.getResult() != null)
                {
                    resetSprites();
                    active = false;
                }
            }
        }
    }

    void OnMouseDown()
    {
        /* Sets conversation active when Player meets collider. */

        if (npc != null && npc.getUsed() || npc == null)
        {
            npc = npcManager.getCurrentClient();
            textKupla.text = "";
            nimiKupla.text = "";
            background.SetActive(false);
            active = false;
            timer = 0f; index = 0; lineRound = 0;
            tempLine = "";
        }

        line = npc.getLine().ToArray();
        nimi = npc.getName();
        sprites = npc.getSprites();

        letters = line[lineRound].ToCharArray();

        active = true;
        clicked = true;
    }

    private void resetSprites()
    {
        background.SetActive(false);
    }
}
