using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("Scripts/Game/Portal")]
public class Portal : MonoBehaviour
{
    public string nameToNextLevel;
    public AudioClip nextLevelClip;
    public Animator animCanvas;
    public float timeToNextLevel;

    private AudioSource source;
    private ScreenManager screenManager;
    private Animator animDoor;
    private bool levelComplete;

    void Start()
    {
        // Procura as referências
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
        source = GetComponent<AudioSource>();
        animDoor = GetComponent<Animator>();
    }

    void OnTriggrEnter(Collider other)
    {
        if (!levelComplete && other.CompareTag("Player"))
        {
            levelComplete = true;
            StartCoroutine("NextLevel");
        }
    }

    IEnumerator NextLevel()
    {
        if (animDoor)
            animDoor.SetTrigger("Open");

        if (nextLevelClip)
        {
            source.PlayOneShot(nextLevelClip, 1.0f);
            yield return new WaitForSeconds(nextLevelClip.length);
        }

        if (animCanvas)
            animCanvas.SetTrigger("LevelComplete");

        yield return new WaitForSeconds(timeToNextLevel);
        screenManager.Load(nameToNextLevel);
    }
}