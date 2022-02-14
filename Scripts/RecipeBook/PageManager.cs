using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PageManager
{

    private int currentPage;
    private int maxPage;

    private static PageManager instance = null;
    public static PageManager Instance   
    {
        get
        {
            if (instance == null)
            {
                instance = new PageManager();
            }
            return instance;
        }
    }

    private PageManager() {
        currentPage = 1;
        maxPage = 3;
    }

     private void setCurrentPage(int page) {
        currentPage = page;
        Debug.Log(currentPage);
    }

    public int getCurrentPage() {
        return currentPage;
    }

    public void changePage(int amt) {
        if (amt < 0) {
            if (currentPage == 1) {
                Debug.Log("Cannot go further back! Current page: " + currentPage);
            } else {
            setCurrentPage(currentPage + amt);
            Debug.Log("PREVIOUS PAGE PRESSED, current page: " + currentPage);
            }
        } else {
            if (currentPage == maxPage) {
                Debug.Log("Cannot go further! Current page: " + currentPage);
            } else {
                setCurrentPage(currentPage + amt);
                Debug.Log("NEXT PAGE PRESSED, current page: " + currentPage);
            }
        }
    }
}
