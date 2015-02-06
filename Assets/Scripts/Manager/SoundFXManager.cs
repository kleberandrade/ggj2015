using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundFXManager : Singleton<SoundFXManager>
{
    [Range(0.0f, 1.0f)]
    public float fxVolume = 1.0f;

    public bool useCameraPosition = true;

    private int sourceAmount = 5;

    private int currentSource = 0;

    private List<AudioSource> sources = new List<AudioSource>();

    void Awake()
    {
        // Adiciona dois AudioSources
        for (int i = 0; i < sourceAmount; i++)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            source.volume = fxVolume;
            source.loop = false;
            source.playOnAwake = false;
            sources.Add(source);
        }
    }

    void Update()
    {
        // Verifica se vai reposicionar o componente na mesma posição da câmera
        if (useCameraPosition && Camera.main != null)
            transform.position = Camera.main.transform.position;
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        if (!clip)
            return;

        sources[currentSource].PlayOneShot(clip, volume);
        currentSource = ++currentSource % sourceAmount;
    }

    public void PlayOneShot(AudioClip clip)
    {
        PlayOneShot(clip, fxVolume);
    }
}
