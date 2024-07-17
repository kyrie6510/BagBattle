using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIGridState
{
    None = 0,
    Bag = 1,
    BagAndItem = 2,
}

public class UIGrid : MonoBehaviour
{
    private BoxCollider2D _collider;
    private Image _imgBg;

    private UIGridState _state;

    public int Id;
    // public int LocalId;
    // public int LocalBagId;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        _imgBg = GetComponent<Image>();
    }

    
}