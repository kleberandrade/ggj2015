using UnityEngine;
using System.Collections;

public class ButtonsClick : MonoBehaviour 
{
    public AudioClip buttonClip;

    private AudioSource buttonAudio;
    private ScreenManager screenManager;

    void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        buttonAudio = GetComponent<AudioSource>();
        if (buttonClip)
            buttonAudio.clip = buttonClip;
    }

    public void StartGameClick()
    {
        Click();
        screenManager.Load("SCharSelect");
    }

	public void CreditsClick()
    {
        Click();
        screenManager.Load("SCredits", "Credits");
	}

	public void ExitClick()
    {
        Click();
        screenManager.Quit();
	}

    void Click()
    {
        if (buttonClip)
        {
            buttonAudio.clip = buttonClip;
            buttonAudio.Play();
        }
            
    }
}
