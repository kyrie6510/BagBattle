using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public  class UICenter : MonoBehaviour
{
    
   
    private static GameObject MainUI;
   
    private static GameObject ShopUI;


    
    
    public static void Show(UIWindow window)
    {
        switch (window)
        {
            case UIWindow.MainUI:
                MainUI.gameObject.SetActive(true);
                break;
            case UIWindow.ShopUI:
                ShopUI.gameObject.SetActive(true);
                break;
        }
        
    }
    
}


public enum UIWindow
{
    MainUI = 0,
    ShopUI = 1,
}
