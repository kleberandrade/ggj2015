using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
    public float time = 4.0f;
    public string sceneName;
    public string backgroundMusic;

    private ScreenManager screenManager;
    private SoundManager soundManager;

	void Start ()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        soundManager = go.GetComponent<SoundManager>();
        if (backgroundMusic != null)
            soundManager.PlayClip(backgroundMusic);
        Invoke("NextScreen", time);
	}
	
	void NextScreen () 
    {
        screenManager.Load(sceneName);
	}
}
