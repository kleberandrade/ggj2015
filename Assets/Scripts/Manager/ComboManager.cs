using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class ComboManager : MonoBehaviour
{
    public delegate void ComboManagerHandler();
    public static event ComboManagerHandler OnStartPlaySequence;
    public static event ComboManagerHandler OnEndPlaySequence;
    public static event ComboManagerHandler OnCorrectSequence;
    public static event ComboManagerHandler OnWrongSequence;

    public AudioClip[] clips;
    public int[] sequence;

    private bool[] hit;
    private int indexSequence = 0;
    private AudioSource comboAudio;

    void Awake()
    {
        comboAudio = GetComponent<AudioSource>();
    }

	public void PlaySequence ()
    {
        StartCoroutine("PlayingSequence");
	}

    IEnumerator PlayingSequence()
    {
        if (OnStartPlaySequence != null)
            OnStartPlaySequence();

        for (int i = 0; i < sequence.Length; i++)
        {
            comboAudio.clip = clips[sequence[i]];
            comboAudio.Play();
            yield return new WaitForSeconds(comboAudio.time);
        }

        if (OnEndPlaySequence != null)
            OnEndPlaySequence();
    }
}
