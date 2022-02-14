using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    * @Author Vertti Ahlstén
    */

public class ReceiptBookAnimationScript : MonoBehaviour
{
    private PageManager manager;

    public GameObject[] pages;

    private void Start()
    {
        manager = PageManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pages.Length; i++) {
            pages[i].SetActive(false);
        }

        pages[(manager.getCurrentPage() -1)].SetActive(true);
    }
}
