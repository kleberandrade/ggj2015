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
    public AudioClip selectClip;
    public AudioClip confirmClip;
    public float timerBetweenMove = 0.2f;

    private int[] playersId = {1, 0, 2};
    private int indexPlayerOne = 1;
    private int indexPlayerTwo = 1;
    private float timerPlayerOne;
    private float timerPlayerTwo;
    private AudioSource selectAudio;

    void Awake()
    {
        selectAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timerPlayerOne += Time.deltaTime;
        timerPlayerTwo += Time.deltaTime;
        SelectPlayerOne();
        SelectPlayerTwo();
        buttonConfirm.interactable = EnableButton();
		if (Input.GetButtonDown ("Attack") && buttonConfirm.interactable) {
			PlayGame();
		}
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
            if (move > 0.0f)
                indexPlayerOne = (++indexPlayerOne) % imagesPlayerOne.Length;
            else
                indexPlayerOne = (imagesPlayerOne.Length + (--indexPlayerOne) % imagesPlayerOne.Length) % imagesPlayerOne.Length;

            timerPlayerOne = 0.0f;
        }

        Select(imagesPlayerOne, indexPlayerOne);
    }

    void SelectPlayerTwo()
    {
        float move = Input.GetAxisRaw("Horizontal2");
        if (move != 0.0f && timerPlayerTwo >= timerBetweenMove)
        {
            if (move > 0.0f)
                indexPlayerTwo = (++indexPlayerTwo) % imagesPlayerTwo.Length;
            else
                indexPlayerTwo = (imagesPlayerTwo.Length + (--indexPlayerTwo) % imagesPlayerTwo.Length) % imagesPlayerTwo.Length;
            
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
        PlayerPrefs.SetInt(PlayerType.Shaman.ToString(), playersId[indexPlayerOne]);
        PlayerPrefs.SetInt(PlayerType.Warrior.ToString(), playersId[indexPlayerTwo]);
        PlayerPrefs.Save();

        Application.LoadLevel("Level_01");
    }
}