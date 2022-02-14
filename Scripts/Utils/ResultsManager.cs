using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsManager
{
    private PlayerController pc;

    private static ResultsManager instance = null;
    public static ResultsManager Instance   
    {
        get
        {
            if (instance == null)
            {
                instance = new ResultsManager();
            }
            return instance;
        }
    }

    private ResultsManager() {
        pc = PlayerController.Instance;

        Text totalCount = GameObject.Find("Canvas/Results/DrinksServedTitle").GetComponent<Text>();
        Text successCount = GameObject.Find("Canvas/Results/SuccessfulOrdersTitle").GetComponent<Text>();
        Text poisonCount = GameObject.Find("Canvas/Results/PoisonServedTitle").GetComponent<Text>();
        Text loveCount = GameObject.Find("Canvas/Results/LoveServedTitle").GetComponent<Text>();
        
        totalCount.text = "Total Drinks Served: " + pc.getTotalDoneBevsCount();
        successCount.text = "Successful Orders: " + pc.getSatisfiedBevsCount();
        poisonCount.text = "Poison Served: " + pc.getServedPoisonCount();
        loveCount.text = "Love Served: " + pc.getServedLoveCount();
    }
}
