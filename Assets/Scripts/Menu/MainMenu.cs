using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Scripts/Menu/MainMenu")]
public class MainMenu : MonoBehaviour 
{
    public Button[] buttons;
    public AudioClip clickClip;
    private int selectedButton = 0;
    private bool selected = false;

    private AudioSource source;
    private ScreenManager screenManager;

    private float vertical;
    private float lastVertical;

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        source = GetComponent<AudioSource>();
    }
	
	void Update () 
    {
        lastVertical = vertical;
        vertical = Input.GetAxisRaw("Vertical1") + Input.GetAxisRaw("Vertical2");

        if (!selected)
        {
            if (lastVertical == 0.0f && vertical < 0)
                Down();
            
            if (lastVertical == 0.0f && vertical > 0)
                Up();

            Highlight(buttons[selectedButton]);

            if (Input.GetButtonDown("Attack1") || Input.GetButtonDown("Attack2"))
            {
                Click(buttons[selectedButton]);
                PlaySound();
            }
        }        
	}

    void Down()
    {
        if (++selectedButton > buttons.Length - 1)
            selectedButton = 0;
    }

    void Up()
    {
        if (--selectedButton < 0)
            selectedButton = buttons.Length - 1;
    }

    void Highlight(Button button)
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
    }

    void Click(Button button)
    {
        selected = true;
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerClickHandler);
    }

    void PlaySound()
    {
        if (clickClip)
            source.PlayOneShot(clickClip, 1.0f);
    }

    public void Credits(string levelName)
    {
        screenManager.Load(levelName, "Credits");
    }

    public void Quit()
    {
        screenManager.Load("Quit");
    }

    public void Play(string levelName)
    {
        screenManager.Load(levelName, "Opening");
    }
}
