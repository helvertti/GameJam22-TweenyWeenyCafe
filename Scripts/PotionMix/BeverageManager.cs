using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeverageManager
{

    private PlayerController pc;
    private List<Ingredient> currentBev;
    private Beverage finishedBev = null;
    private static BeverageManager instance = null;
    public static BeverageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BeverageManager();
            }
            return instance;
        }
    }

    private BeverageManager() {
        pc = PlayerController.Instance;
        currentBev = new List<Ingredient>();
    }

    public bool addIngredient(string name) {
        if (currentBev.Count < 4)
        {
            Ingredient i = pc.ingr(name);
            if (i == null) {
                Debug.Log("Impossible ingredient!");
                return false;
            }
            currentBev.Add(i);
            Debug.Log("Added " + i.getName());
            return true;
        }
        Debug.Log("The pot is full, could not add " + name);
        return false;
    }

    public bool resetBev() {
        
        if (currentBev.Count < 1) {
            Debug.Log("No ingredients to reset yet.");
            return false;
        }
        Debug.Log("resetting drink that has " + string.Join("+", currentBev));
        currentBev = new List<Ingredient>();
        return true;
    }

    public bool finishBev() {
        if (currentBev.Count > 0)
        {
            finishedBev = pc.bevrByList(currentBev);
            Debug.Log(finishedBev.getName() + " finished!");

            currentBev = new List<Ingredient>();
            return true;
        }
        Debug.Log("Not enough ingredients to finish. At least 1 needed!");
        return false;
    }

    public Beverage getFinishedBev() {
        return finishedBev;
    }

}
