using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBookClickScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        
    }
    
    public void goBack()
    {
        Debug.Log("Changing Scene to PotionMix");
        LoaderScript.Load(LoaderScript.Scene.PotionMixScene);
    }
}
