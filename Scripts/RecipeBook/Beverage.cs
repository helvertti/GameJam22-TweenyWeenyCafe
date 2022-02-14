using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class Beverage
{
    public string name;
    public List<Ingredient> properties;
    public bool onLocked;

    public Beverage(string name, List<Ingredient> properties)
    {
        this.name = name;
        this.properties = properties;
    }

    public void setOnLocked(bool locked) {
        this.onLocked = locked;
    }

    public string getName()
    {
        return name;
    }

    public void addIngredient(Ingredient ing) {
        properties.Add(ing);
    }

    public List<Ingredient> getProperties()
    {
        return properties;
    }

    public bool hasIngredient(string ing) {
        for (int i = 0; i < properties.Count; i++) {
            if (properties[i].getName() == ing) {
                return true;
            }
        }
        return false;
    }
}
