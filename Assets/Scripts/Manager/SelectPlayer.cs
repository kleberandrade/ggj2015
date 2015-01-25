using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SelectPlayer : MonoBehaviour
{
    public Image[] imagesPlayerOne;
    public Image[] imagesPlayerTwo;
    public Button buttonConfirm;
    public AudioClip moveClip;
    //public AudioClip selectClip;
    public AudioClip confirmClip;
    public float timerBetweenMove = 0.2f;

    private int[] playersId = { 1, 0, 2 };
    private int indexPlayerOne = 1;
    private int indexPlayerTwo = 1;
    private float timerPlayerOne;
    private float timerPlayerTwo;
    private AudioSource selectAudio;
    private ScreenManager screenManager;

    void Awake()
    {
        selectAudio = GetComponent<AudioSource>();
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
    }

    void Update()
    {
        timerPlayerOne += Time.deltaTime;
        timerPlayerTwo += Time.deltaTime;
        SelectPlayerOne();
        SelectPlayerTwo();
        buttonConfirm.interactable = EnableButton();

        if ((Input.GetButtonDown("Attack1") || Input.GetButtonDown("Attack2")) && buttonConfirm.interactable)
            PlayGame();

        if (Input.GetKeyDown(KeyCode.Escape))
            BackGame();
    }

    void Select(Image[] images, int index)
    {
        for (int i = 0; i < images.Length; i++)
            images[i].gameObject.SetActive(i == index);
    }

    void SelectPlayerOne()
    {
        float move = Input.GetAxisRaw("Horizontal1");
        if (move != 0.0f && timerPlayerOne >= timerBetweenMove)
        {
            selectAudio.clip = moveClip;
            selectAudio.Play();
            if (move > 0.0f)
                indexPlayerOne = imagesPlayerOne.Length > 0 ? (++indexPlayerOne) % imagesPlayerOne.Length : indexPlayerOne;
            else
                indexPlayerOne = imagesPlayerOne.Length > 0 ? (imagesPlayerOne.Length + (--indexPlayerOne) % imagesPlayerOne.Length) % imagesPlayerOne.Length : indexPlayerOne;

            timerPlayerOne = 0.0f;
        }

        Select(imagesPlayerOne, indexPlayerOne);
    }

    void SelectPlayerTwo()
    {
        float move = Input.GetAxisRaw("Horizontal2");
        if (move != 0.0f && timerPlayerTwo >= timerBetweenMove)
        {
            selectAudio.clip = moveClip;
            selectAudio.Play();
            if (move > 0.0f)
                indexPlayerTwo = imagesPlayerTwo.Length > 0 ? (++indexPlayerTwo) % imagesPlayerTwo.Length : indexPlayerTwo;
            else
                indexPlayerTwo = imagesPlayerTwo.Length > 0 ? (imagesPlayerTwo.Length + (--indexPlayerTwo) % imagesPlayerTwo.Length) % imagesPlayerTwo.Length : indexPlayerTwo;

            timerPlayerTwo = 0.0f;
        }

        Select(imagesPlayerTwo, indexPlayerTwo);
    }

    bool EnableButton()
    {
        if (indexPlayerOne == 1)
            return false;

        if (indexPlayerTwo == 1)
            return false;

        if (indexPlayerOne == indexPlayerTwo)
            return false;

        return true;
    }

    public void PlayGame()
    {
        selectAudio.clip = confirmClip;
        selectAudio.Play();

        PlayerPrefs.SetInt(PlayerType.Shaman.ToString(), playersId[indexPlayerOne]);
        PlayerPrefs.SetInt(PlayerType.Warrior.ToString(), playersId[indexPlayerTwo]);
        PlayerPrefs.Save();

        screenManager.Load("Level_01", "Level1");
    }

    public void BackGame()
    {
        selectAudio.clip = confirmClip;
        selectAudio.Play();

        screenManager.Load("SMainMenu");
    }
}