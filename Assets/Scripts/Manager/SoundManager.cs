using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    [Range(0.0f, 10.0f)]
	public float transitionTime = 1.0f;

	private AudioSource[] sources = new AudioSource[2];
	private float[] finalVolumes = {0.0f, 0.6f};
	private int currentSource = 1;

	void Awake()
    {
        sources[0] = gameObject.AddComponent<AudioSource>();
        sources[0].loop = true;
        sources[1] = gameObject.AddComponent<AudioSource>();
        sources[1].loop = true;
	}

	public void PlayClip(string clipName)
    {
        if (clipName == null)
            return;

        if (clipName == string.Empty)
            return;

        AudioClip clip = Resources.Load<AudioClip>("Audios/Music/" + clipName);
        if (clip == null)
            return;

        if (clip == sources[currentSource].clip)
            return;

		finalVolumes [currentSource] = 0.0f;
		SwapCurrent ();
		finalVolumes [currentSource] = 0.6f;
        sources[currentSource].clip = clip;
		sources [currentSource].Play ();
	}

	void SwapCurrent()
    {
		currentSource = (++currentSource) % 2;
	}

	void Update()
    {
        if (Camera.main != null)
            transform.position = Camera.main.transform.position;

		sources [0].volume = Mathf.Lerp (sources [0].volume, finalVolumes [0], transitionTime * Time.deltaTime);
		sources [1].volume = Mathf.Lerp (sources [1].volume, finalVolumes [1], transitionTime * Time.deltaTime);
	}
}
