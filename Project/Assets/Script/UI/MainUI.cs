using System.Collections;
using System.Collections.Generic;
using Script.Event;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    public Button BtnPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        BtnPlay.onClick.AddListener(OnGamePlay);
    }

    private void OnGamePlay()
    {
        EventManager.Instance.TriggerEvent(new OnGamePlayEvent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
