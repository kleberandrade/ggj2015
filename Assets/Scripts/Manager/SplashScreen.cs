using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour 
{
    public float time = 4.0f;
    public string sceneName;

	void Start ()
    {
        Invoke("NextScreen", time);
	}
	
	void NextScreen () 
    {
        Application.LoadLevel(sceneName);
	}
}
