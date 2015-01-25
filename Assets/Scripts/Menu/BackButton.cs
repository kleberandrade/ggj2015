using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

[RequireComponent (typeof(AudioSource))]
public class BackButton : MonoBehaviour 
{
    public string previousScene;
    public string backgroundMusic;
    public GameObject button;
    public AudioClip buttonClip;

    private AudioSource buttonAudio;
    private ScreenManager screenManager;

	void Awake () 
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        buttonAudio = GetComponent<AudioSource>();
	}
	
	void Update () 
    {
        if (Input.GetButtonDown("Attack"))
        {
            var pointer = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(button, pointer, ExecuteEvents.pointerClickHandler);
        }
	}

    public void  Click()
    {
        if (buttonClip)
        {
            buttonAudio.clip = buttonClip;
            buttonAudio.Play();
        }
            
        screenManager.Load(previousScene, backgroundMusic);
    }
}
