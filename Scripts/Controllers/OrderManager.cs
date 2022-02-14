using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager {
  private static OrderManager instance = null;
  BeverageManager bevManager;
  PlayerController pc;

    public static OrderManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new OrderManager();
            }
            return instance;
        }
    }

    private OrderManager() {
      bevManager = BeverageManager.Instance;  
      pc = PlayerController.Instance;
    }

    public bool executeOrder(Beverage orderedBev) {
      Beverage servedBev = bevManager.getFinishedBev();

      pc.increaseTotalDoneBevsCount();
      Debug.Log("Total Beverages Served now: " + pc.getTotalDoneBevsCount());

      if (servedBev.hasIngredient("purple root")) {
        Debug.Log(servedBev.getName() + " contains POISON.");
        pc.increaseServedPoisonCount();
      }
      if (servedBev.hasIngredient("love fruit")) {
        Debug.Log(servedBev.getName() + " contains LOVE");
        pc.increaseServedLoveCount();
      }

      if (orderedBev.getName().ToLower() == servedBev.getName().ToLower()) {
        Debug.Log("product was same as order");
        pc.increaseSatisfiedBevsCount();
        return true;
      }

      Debug.Log("product was NOT the same as order");
      return false;
    }

}