using UnityEngine;
using System.Collections;

[AddComponentMenu("Scripts/Game/Portal")]
public class Portal : MonoBehaviour
{
    public string nameToNextLevel;
    public AudioClip nextLevelClip;
    public Animator animCanvas;
    public float timeToNextLevel;
    public Collider doorCollider;

    private SoundFXManager soundFX;
    private ScreenManager screenManager;
    private Animator animDoor;
    private bool levelComplete;

    void Start()
    {
        screenManager = ScreenManager.Instance;
        soundFX = SoundFXManager.Instance;
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

        if (doorCollider)
            doorCollider.isTrigger = true;

        if (nextLevelClip)
        {
            soundFX.PlayOneShot(nextLevelClip);
            yield return new WaitForSeconds(nextLevelClip.length);
        }

        if (animCanvas)
            animCanvas.SetTrigger("LevelComplete");

        yield return new WaitForSeconds(timeToNextLevel);
        screenManager.Load(nameToNextLevel);
    }
}