using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class IdleAnimationScript : MonoBehaviour
{
    public GameObject[] anim;
    private int index, time;

    private void Start()
    {
        index = 0; time = 0;

        for (int i = 1; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (time >= 20)
        {
            nextChange();
            time = 0;
        }

        time += 1;
    }

    private void nextChange()
    {
        anim[index].SetActive(false);
        index += 1;
        if (index >= anim.Length) index = 0;
        anim[index].SetActive(true);
    }
}
