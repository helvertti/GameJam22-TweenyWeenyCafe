using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic {
  private static GameLogic instance = null;
  private NPCManager npcManager;
  private OrderManager orderManager;
  private PlayerController pController;
    public static GameLogic Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameLogic();
            }
            return instance;
        }
    }

    private GameLogic() {
      npcManager = NPCManager.Instance;  
      orderManager = OrderManager.Instance;
      pController = PlayerController.Instance;
    }

    public void makeAnOrder() {
      
      Beverage order = pController.bevr(npcManager.getCurrentClient().getDrink());

      bool successfulOrder = orderManager.executeOrder(order);

      if (successfulOrder) {
        npcManager.setResult("good");
      } else {
        npcManager.setResult("bad");
      }

    }

}