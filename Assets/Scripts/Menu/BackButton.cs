using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour 
{
    public string previousScene;
    public string backgroundMusic;
    public GameObject button;

    private ScreenManager screenManager;

	void Awake () 
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
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
        screenManager.Load(previousScene, backgroundMusic);
    }
}
