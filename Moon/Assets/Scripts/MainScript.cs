using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    [SerializeField] float usaPositionY;
    [SerializeField] float ussrPositionY;
    
    [SerializeField] float usaRate;
    [SerializeField] float ussrRate;
    [SerializeField] int winRate;
    
    [SerializeField] bool randomMode;

    public Canvas settingCanvas;
    public Toggle randomModeToggle;

    public Button startButton;
    public Text usaRateText;
    public Text ussrRateText;
    public Text winText;
    public Image usaShuttle;
    public Image ussrShuttle;

    public void ButtonUSAClick()
    {
        usaRate++;
    }
    
    public void ButtonClick()
    {
        ussrRate++;
    }
    
    public void OpenSetting() {
        if (settingCanvas.enabled == true) {
            settingCanvas.enabled = false;
        } else {
            settingCanvas.enabled = true;
        }
        
        
    }
    
    public void ButtonClickStartGame()
    {
        ussrRate = 0;
        usaRate = 0;
        winRate = 100;
        startButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }
    
    void Refresh()
    {
        Vector3 pos = usaShuttle.transform.position;
        pos.y = usaPositionY;
        usaShuttle.transform.position = pos;
        
        Vector3 pos2 = ussrShuttle.transform.position;
        pos2.y = ussrPositionY;
        ussrShuttle.transform.position = pos2;
    }

    // Start is called before the first frame update
    void Start()
    {
        settingCanvas.enabled = false;
        usaPositionY = usaShuttle.transform.position.y;
        ussrPositionY = ussrShuttle.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        string currTaskText = "Win USSR!";
        string winUSA = "Win USA!";

        Vector3 pos = usaShuttle.transform.position;
        pos.y = usaPositionY + (usaRate / 20f);
        usaShuttle.transform.position = pos;
        
        Vector3 pos2 = ussrShuttle.transform.position;
        pos2.y = ussrPositionY + (ussrRate / 20f);
        ussrShuttle.transform.position = pos2;
    
        if (ussrRate >= winRate)
        {
            winText.text = currTaskText;
            startButton.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            Refresh();
        }
        
        if (usaRate >= winRate)
        {
            winText.text = winUSA;
            startButton.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            Refresh();
        }
    
        usaRateText.text = usaRate.ToString();
        ussrRateText.text = ussrRate.ToString();
    }
}
