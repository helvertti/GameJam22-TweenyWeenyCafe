using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    /*
     * @Author Vertti Ahlstén
     */

public class NPCManager
{
    private static NPCManager instance = null;

    private List<NPCCharacter> characterList;

    private NPCCharacter current;
    private string result = null;

    public static NPCManager Instance{
        get {
            if (instance == null) instance = new NPCManager();
            return instance;
        }
    }

    private NPCManager() {
        characterList = new List<NPCCharacter>();
    }

    public void generateNPC() {
        // Generate new client.
        if (!string.IsNullOrEmpty(characterList.Last().getName()))
        {
            NPCCharacter[] npcs = characterList.ToArray();
            int rand = Random.Range(1, npcs.Length);
            //Debug.Log(rand);

            while (npcs[rand].getUsed()) {
                rand = Random.Range(0, npcs.Length);
            }

            result = null;
            current = npcs[rand];
        }
        else current = null;
    }

    public NPCCharacter getCurrentClient() {
        //Debug.Log(characterList.Count);
        return current;
    }

    public void setCurrentNull() { current = null; }

    public void setResult(string result) {
        this.result = result;
        current.setResult(result);
    }

    public string getResult() {
        return result;
    }

    public void setClient(string name, string drink, string[] lines, GameObject[] sprites) {
        NPCCharacter[] npcs = characterList.ToArray();
        bool goon = true;

        for(int i = 0; i < npcs.Length; i++)
        {
            if (npcs[i].getName() == name && npcs[i].getDrink() == drink && npcs[i].getLine().ToArray()[0] == lines[0])
            {
                //Debug.Log("Same object");
                npcs[i].setSprites(sprites);
                goon = false;
                break;
            }
        }

        Debug.Log("Different object");
        if(goon) characterList.Add(new NPCCharacter(name, drink, lines.ToList<string>(), sprites));
    }
}
