using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Item/ItemBehavior")]
public class ItemBehavior : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource itemAudio;
    private ComboManager comboManager;

    void Awake()
    {
        itemAudio = GetComponent<AudioSource>();
        comboManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ComboManager>();
    }

    public void Behave()
    {
        itemAudio.clip = clip;
        itemAudio.Play();
        comboManager.ItemUsed(clip);
    }
}
