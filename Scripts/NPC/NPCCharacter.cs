using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @Author Vertti Ahlstén
 */


[Serializable]
public class NPCCharacter
{
    private string name, drink, result;
    private List<string> line;
    private GameObject[] sprites;
    private bool used;

    public NPCCharacter(string name, string drink, List<string> line, GameObject[] sprites) {
        this.name = name;
        this.drink = drink;
        this.line = line;
        this.sprites = sprites;
        used = false;
        result = "";
    }

    public string getName() { return name; }

    public string getDrink() { return drink; }

    public List<string> getLine() { return line; }

    public void setLine(List<string> line)
    {
        this.line = line;
    }

    public GameObject[] getSprites() { return sprites; }

    public void setSprites(GameObject[] sprites)
    {
        this.sprites = sprites;
    }

    public void setUsed(bool used) { this.used = used; }

    public bool getUsed() { return used; }

    public void setResult(string result) { this.result = result; }

    public string getResult() { return result; }
       
}
