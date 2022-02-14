using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */
public class Ingredient
{
    public string name;
    public enum property { SOUR, SWEET, POISON, BITTER };

    public Ingredient(string name, property Property) {
        this.name = name;
        this.Property = Property;
    }

    public property Property { get; set; }

    void setName(string name) { this.name = name; }

    public string getName() { return name; }

    public override string ToString() {
        return name;
    }
    
}
