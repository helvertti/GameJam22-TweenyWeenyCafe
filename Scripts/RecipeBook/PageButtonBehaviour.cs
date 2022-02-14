using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageButtonBehaviour : MonoBehaviour
{
    private PageManager manager;
    void Start()
    {
        manager = PageManager.Instance;
    }

    void Update()
    {
        
    }

    public void changePageBy(int amt) {
        manager.changePage(amt);
    }
}
