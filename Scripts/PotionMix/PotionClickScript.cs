using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class PotionClickScript : MonoBehaviour
{
    private BeverageManager bevManager;
    private GameLogic gameLogic;
    public string name;
    public GameObject FinishNappi;

    private void Start()
    {
        bevManager = BeverageManager.Instance;
        gameLogic = GameLogic.Instance;

        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }
    }

    public void ClickType()
    {
        bool res = bevManager.addIngredient(name);

        //addIngredient returns true/false. Activate text for user if result false.
        //It means, the drink is full. Needs to be reseted or finished.
    }

    public void resetDrink()
    {
        Debug.Log("Resetting drink");
        bevManager.resetBev();
    }

    public void finishDrink()
    {
        Debug.Log("Finishing drink");
        if (bevManager.finishBev()) {
            gameLogic.makeAnOrder();
            LoaderScript.Load(LoaderScript.Scene.RestaurantScene);
        }
    }

    public void goToRecipes()
    {
        Debug.Log("Going to Recipe Book");
        LoaderScript.Load(LoaderScript.Scene.RecipeBookScene);
    }

    public void goToRestaurant()
    {
        Debug.Log("Going to Restaurant");
        LoaderScript.Load(LoaderScript.Scene.RestaurantScene);
    }

}
