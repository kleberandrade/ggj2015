using System.Collections;
using UnityEngine;

[AddComponentMenu("Scripts/Manager/ScreenManager")]
public class ScreenManager : Singleton<ScreenManager>
{
    private Fade fade;
    private SoundManager soundManager;

    void Awake()
    {
        fade = Fade.Instance;
        soundManager = SoundManager.Instance;
    }

    public void Load(string name)
    {
        StartCoroutine("Loading", name);
    }

    public void Load(string name, string audioClip)
    {
        soundManager.PlayClip(audioClip);
        StartCoroutine("Loading", name);
    }

    IEnumerator Loading(string name)
    {
        yield return new WaitForSeconds(fade.BeginFade(FadeDir.Out));

        if (!name.Equals("Quit"))
        {
            Application.LoadLevel(name);
        }
        else
        {
            Application.Quit();
        }
    }

    public void Quit()
    {
        StartCoroutine("Loading", "Quit");
    }

    public void Pause()
    {
        Time.timeScale = 1.0f - Time.timeScale;
    }
}