using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
[AddComponentMenu("Scripts/Game/ComboManager")]
public class ComboManager : MonoBehaviour
{
    public delegate void ComboManagerHandler();
    public static event ComboManagerHandler OnStartPlaySequence;
    public static event ComboManagerHandler OnEndPlaySequence;
    //public static event ComboManagerHandler OnCorrectSequence;
    //public static event ComboManagerHandler OnWrongSequence;

    public Animator canvasAnim;
    public AudioClip wrongSequence;
    public AudioClip levelCleared;
    public AudioClip[] clips;
    public int[] sequence;
    public float delay = 2.0f;

    private bool[] hit;
    private int indexSequence = 0;
    private AudioSource comboAudio;

    void Awake()
    {
        comboAudio = GetComponent<AudioSource>();
        hit = new bool[sequence.Length];
    }

    public void PlaySequence()
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
            yield return new WaitForSeconds(clips[sequence[i]].length);
        }

        if (OnEndPlaySequence != null)
            OnEndPlaySequence();
    }

    public void ItemUsed(AudioClip audio)
    {
        if (clips[sequence[indexSequence]] == audio)
        {
            hit[indexSequence++] = true;
        }
        else
        {
            PlaySound(false);
            ResetSequenceCursor();
        }
        if (indexSequence == sequence.Length)
        {
            PlaySound(true);
            Invoke("LevelClear", 4.0f);
        }
            
    }

    void ResetSequenceCursor()
    {
        for (int i = 0; i < indexSequence; i++)
            hit[i] = false;
        indexSequence = 0;
    }

    void PlaySound(bool cleared)
    {
        if (cleared)
            comboAudio.clip = levelCleared;
        else
            comboAudio.clip = wrongSequence;
        comboAudio.Play();
    }

    void TryAgain()
    {
        canvasAnim.SetTrigger("Lose");
    }

    void LevelClear()
    {
        canvasAnim.SetTrigger("Win");
    }
}
