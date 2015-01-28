using UnityEngine;
using System.Collections;

/// <summary>
/// Gerênciador de música de fundos
/// </summary>
[AddComponentMenu("Scripts/Manager/SoundManager")]
public class SoundManager : MonoBehaviour 
{
    /// <summary>
    /// Tempo de transição entre uma música e outra (em segundos)
    /// </summary>
    [Range(0.0f, 10.0f)]
    public float transitionTime = 1.0f;

    /// <summary>
    /// Volume final do audio
    /// </summary>
    [Range(0.0f, 1.0f)]
    public float finalVolume = 0.6f;

    /// <summary>
    /// Caminho dentro da pasta de Resources
    /// </summary>
    public string musicPath = "Audios/Music/";

    /// <summary>
    /// Usar a posição da câmera para emitir os sons
    /// </summary>
    public bool useCameraPosition = true;

    /// <summary>
    /// Volumes finais das músicas
    /// </summary>
    private float[] finalVolumes = new float[2];

    /// <summary>
    /// Origem das trilhas sonoras
    /// </summary>
    private AudioSource[] sources = new AudioSource[2];

    /// <summary>
    /// Qual a trilha sonora que esta tocando atualmente
    /// </summary>
    private int currentSource = 1;

    /// <summary>
    /// Método inicial a ser executado
    /// </summary>
    void Awake()
    {
        // Adiciona dois AudioSources
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i] = gameObject.AddComponent<AudioSource>();
            sources[i].loop = true;
        }

        // Procura a chave MusicLevel para pegar o volume do som
        if (!PlayerPrefs.HasKey("MusicLevel")) 
        {
            finalVolume = PlayerPrefs.GetFloat("MusicLevel");
        }
        else
        {
            PlayerPrefs.SetFloat("MusicLevel", finalVolume);
            PlayerPrefs.Save();
        }
        
        finalVolumes[0] = 0.0f;
        finalVolumes[1] = finalVolume;
    }

    /// <summary>
    /// Troca um Audio Clip que esteja na pasta Assets/Resources/Audios/Music"
    /// </summary>
    /// <param name="clipName">Nome da música a ser tocada</param>
	public void PlayClip(string clipName)
    {
        if (clipName == null)
            return;

        if (clipName == string.Empty)
            return;

        AudioClip clip = Resources.Load<AudioClip>(musicPath + clipName);
        if (clip == null)
            return;

        if (clip == sources[currentSource].clip)
            return;

		SwapCurrent ();

        sources[currentSource].clip = clip;
		sources [currentSource].Play ();
	}

    /// <summary>
    /// Troca o volume entre as trilhas sonoras
    /// </summary>
	void SwapCurrent()
    {
        finalVolumes[currentSource] = 0.0f;
		currentSource = (++currentSource) % 2;
        finalVolumes[currentSource] = finalVolume;
	}

    /// <summary>
    /// Faz a transição das músicas quando necessário
    /// </summary>
	void Update()
    {
        // Verifica se vai reposicionar o componente na mesma posição da câmera
        if (useCameraPosition && Camera.main != null)
            transform.position = Camera.main.transform.position;

        // Faz a transição dos volumes entre as duas trilhas
		sources [0].volume = Mathf.Lerp (sources [0].volume, finalVolumes [0], transitionTime * Time.deltaTime);
		sources [1].volume = Mathf.Lerp (sources [1].volume, finalVolumes [1], transitionTime * Time.deltaTime);
	}
}
