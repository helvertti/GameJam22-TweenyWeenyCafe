using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * @Author Vertti Ahlstén
 */

public class LoaderCallbackScript : MonoBehaviour
{
    public float time;

    private bool isFirstUpdate = true;
    private float count;

    private void Start()
    {
        count = 0f;
    }

    void Update()
    {
        /* Manually slows down loading time - Loading screen doesn´t flash, even if there's no much content on next scene.
         * It takes the minimum time to load.
         */

        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("Esc pressed.");
            Application.Quit();
        }

        count += 0.1f;

        if (isFirstUpdate && count >= time)
        {
            isFirstUpdate = false;
            LoaderScript.LoaderCallback();
        }

    }
}
