using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float fadeTime = 0.8f;
    
    private int drawDepth = -1000;
    private Texture2D fadeOutTexture;
    private FadeDir fadeDir = FadeDir.In;
    private float alpha = 1.0f;
    private float startTime;

    void Start()
    {
        if (!fadeOutTexture)
        {
            fadeOutTexture = new Texture2D(2, 2);
            for (var mip = 0; mip < 2; ++mip)
                for (var cols = 0; cols < 2; ++cols)
                    fadeOutTexture.SetPixel(cols, mip, Color.black);

            fadeOutTexture.Apply();
        }
    }

    void OnGUI()
    {
        if (fadeDir == FadeDir.Out)
            alpha = Mathf.Lerp(0.0f, 1.0f, ((Time.time - startTime) / fadeTime));
        else
            alpha = Mathf.Lerp(1.0f, 0.0f, ((Time.time - startTime) / fadeTime));

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    /// <summary>
    /// Método para iniciar o efeito de fade (In ou Out)
    /// </summary>
    /// <param name="direction">Direção do Efeito, pode ser de saida (Out) ou de entrada (In) </param>
    /// <returns>Tempo de duração do efeito</returns>
    public float BeginFade(FadeDir direction)
    {
        startTime = Time.time;
        fadeDir = direction;
        return fadeTime;
    }

    /// <summary>
    /// Método chamado depois que a cena é carregada
    /// </summary>
    void OnLevelWasLoaded()
    {
        BeginFade(FadeDir.In);
    }
}

public enum FadeDir
{
    In = -1,            // Fade In
    Out = 1             // Fade Out
}