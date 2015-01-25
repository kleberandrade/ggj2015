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
        if (buttonClip)
            buttonAudio.Play();
        screenManager.Load("SCharSelect");
    }

	public void CreditsClick()
    {
        if (buttonClip)
            buttonAudio.Play();
        screenManager.Load("SCredits", "Credits");
	}

	public void ExitClick()
    {
        if (buttonClip)
            buttonAudio.Play();
        screenManager.Quit();
	}
}
