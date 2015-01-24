using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public int timeInSeconds = 3600;
    public Text timeText;

    private float startTime;
    private float remainingTime;

	void Awake () 
    {
        if (PlayerPrefs.HasKey("TimeInSeconds"))
            timeInSeconds = PlayerPrefs.GetInt("TimeInSeconds");
	}

    void Start()
    {
        startTime = Time.time;
    }
	
	void Update () 
    {
        remainingTime = timeInSeconds - (Time.time - startTime);
        int minute = (int)(remainingTime / 60);
        int second = (int)((remainingTime - minute * 60) % 60); 
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
	}

    void OnDisable()
    {
        PlayerPrefs.SetInt("TimeInSeconds", (int)remainingTime);
        PlayerPrefs.Save();
    }
}
