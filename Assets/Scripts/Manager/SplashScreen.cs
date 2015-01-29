using UnityEngine;
using System.Collections;

/// <summary>
/// Define se a cena será uma cena de splash onde tem um tempo para sair
/// </summary>
[AddComponentMenu("Scripts/Manager/SplashScreen")]
public class SplashScreen : MonoBehaviour 
{
    /// <summary>
    /// Tempo de transição entre as cenas
    /// </summary>
    [Range(0.01f, 10.0f)]
    public float time = 4.0f;

    /// <summary>
    /// Nome da próxima cena
    /// </summary>
    public string nextSceneName;

    /// <summary>
    /// Nome da música de fundo se precisa tocar algo
    /// </summary>
    public string backgroundMusic;

    /// <summary>
    /// Referência para o gerênciador de cena
    /// </summary>
    private ScreenManager screenManager;

    /// <summary>
    /// Referência para o gerênciador de música de fundo
    /// </summary>
    private SoundManager soundManager;

    /// <summary>
    /// Inicia o objeto
    /// </summary>
	void Start ()
    {
        // Procura as referências
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        soundManager = go.GetComponent<SoundManager>();

        // Toca a música se existir
        if (backgroundMusic != null)
            soundManager.PlayClip(backgroundMusic);

        // Inicia a coroutine NextScreen
        StartCoroutine("NextScreen", time);
	}

	/// <summary>
    /// Coroutine para trocar a cena depois de um periodo de tempo
	/// </summary>
	/// <param name="time">tempo de espera</param>
	/// <returns></returns>
	IEnumerator NextScreen (float time) 
    {
        // Espera um tempo
        yield return new WaitForSeconds(time);
        // Troca a cena
        screenManager.Load(nextSceneName, backgroundMusic);
	}
}
