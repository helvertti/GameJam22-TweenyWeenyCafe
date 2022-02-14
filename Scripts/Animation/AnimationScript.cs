using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class AnimationScript : MonoBehaviour
{
    public GameObject[] anim;
    private int index, time, round, rounds;
    private bool start, clicked;

    void Start()
    {
        index = 0; time = 0; round = 0;
        rounds = anim.Length - 1;
        start = false; clicked = false;

        /* Deactivates all added sprites expect the first one - anim[0] */
        for (int i = 1; i < anim.Length; i++)
        {
            anim[i].SetActive(false);
        }

    }

    private void FixedUpdate()
    {
        if (start) {

            if (time >= 20 && round <= rounds) {
                nextChange();
                time = 0;
                round += 1;

                if (round >= rounds)
                {
                    start = false;
                    clicked = false;
                    round = 0;
                }
            }
            time += 1;
        }
    }

    private void OnMouseDown()
    {
        start = true;
        clicked = true;
    }

    private void nextChange()
    {
        /* Deactivates sprite that has been on and then activates next one */

        anim[index].SetActive(false);
        index += 1;
        if (index >= anim.Length) index = 0;
        anim[index].SetActive(true);
    }
}
