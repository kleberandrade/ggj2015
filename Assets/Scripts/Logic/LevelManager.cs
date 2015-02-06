using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public string nameLevelMusic;

    private ScreenManager screenManager;
    private SoundManager soundManager;

    void Start()
    {
        screenManager = ScreenManager.Instance;
        soundManager = SoundManager.Instance;
        soundManager.PlayClip(nameLevelMusic);
    }
}
