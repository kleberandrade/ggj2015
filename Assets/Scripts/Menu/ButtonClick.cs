using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent (typeof(AudioSource))]
[AddComponentMenu("Scripts/Helper/ButtonClick")]
public class ButtonClick : MonoBehaviour 
{
    /// <summary>
    /// Referência para o botão utilizado na UI
    /// </summary>
    public Button button;

    /// <summary>
    /// Nome do botão que vai acionar o evento de click
    /// </summary>
    public string inputName = "Attack";

    /// <summary>
    /// Cena que o botão chamara ao ser clicado
    /// </summary>
    public string nextScene;

    /// <summary>
    /// Música que será tocada ao clicar no botão
    /// </summary>
    public string nextMusic;

    /// <summary>
    /// Efeito sonoro de click no botão
    /// </summary>
    public AudioClip buttonClip;

    /// <summary>
    /// Referência para o tocador de música
    /// </summary>
    private AudioSource source;

    /// <summary>
    /// Referência pra o gerenciador de cenas
    /// </summary>
    private ScreenManager screenManager;

    /// <summary>
    /// Flag que indica se o botão foi pressionado
    /// </summary>
    private bool clicked = false;

    /// <summary>
    /// Pega as referências
    /// </summary>
    void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        source = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Verifica se a tecla foi pressionada
    /// </summary>
    void Update()
    {
        if (Input.GetButtonDown(inputName + "1") || Input.GetButtonDown(inputName + "2"))
        {
            if (!clicked)
            {
                clicked = true;
                StartCoroutine("Clicking");
            }
        }
    }

    /// <summary>
    /// Evento de click que deve ser usado no botão
    /// </summary>
    public void Click()
    {
        if (buttonClip)
            source.PlayOneShot(buttonClip, 1.0f);
        screenManager.Load(nextScene, nextMusic);   
    }

    /// <summary>
    /// Sobrecarga do evento de click que deve ser usado no botão
    /// </summary>
    public void Click(string nextScene)
    {
        this.nextScene = nextScene;
        Click();
    }

    /// <summary>
    /// Simula os efeitos que acontecem ao clicar no botão
    /// </summary>
    IEnumerator Clicking()
    {
        var pointer = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerDownHandler);
        yield return new WaitForSeconds(0.01f);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerUpHandler);
        yield return new WaitForSeconds(0.01f);
        ExecuteEvents.Execute(button.gameObject, pointer, ExecuteEvents.pointerClickHandler);
    }
}
