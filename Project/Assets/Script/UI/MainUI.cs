using Game;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField]
    public Button BtnPlay;
    
    public Text Txt_Tick;
    
    // Start is called before the first frame update
    void Start()
    {
        
        EventManager.Instance.AddListener<OnWorldTick>(OnWorldTick);
        BtnPlay.onClick.AddListener(OnGamePlay);
    }

    private void OnWorldTick(OnWorldTick e)
    {
        Txt_Tick.text = $"{e.Tick}";
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
