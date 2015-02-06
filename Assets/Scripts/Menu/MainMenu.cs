using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[AddComponentMenu("Scripts/Menu/MainMenu")]
public class MainMenu : MonoBehaviour 
{
    public Button[] buttons;
    public AudioClip clickClip;
    public AudioClip moveClip;
    private int selectedButton = 0;
    private bool selected = false;

    private SoundFXManager soundFX;
    private ScreenManager screenManager;

    private float vertical;
    private float lastVertical;

    void Start()
    {
        screenManager = ScreenManager.Instance;
        soundFX = SoundFXManager.Instance;
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
                soundFX.PlayOneShot(clickClip, 1.0f);
            }
        }        
	}

    void Down()
    {
        if (++selectedButton > buttons.Length - 1)
            selectedButton = 0;

        soundFX.PlayOneShot(moveClip, 1.0f);
    }

    void Up()
    {
        if (--selectedButton < 0)
            selectedButton = buttons.Length - 1;

        soundFX.PlayOneShot(moveClip, 1.0f);
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
