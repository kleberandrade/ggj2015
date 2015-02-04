using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public string nameLevelMusic;

    private ScreenManager screenManager;
    private SoundManager soundManager;

    void Start()
    {
        // Procura as referências
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        soundManager = go.GetComponent<SoundManager>();

        // Toca a música se existir
        if (nameLevelMusic != null)
            soundManager.PlayClip(nameLevelMusic);
    }
}
