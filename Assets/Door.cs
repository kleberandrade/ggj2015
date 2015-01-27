using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class Door : MonoBehaviour 
{
    public string nextLevel;
    public string nextSound;
    public ScreenManager screenManager;

    void Awake()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Manager");
        screenManager = go.GetComponent<ScreenManager>();
	}

    void Start()
    {
        collider.isTrigger = true;
    }

	void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player"))
            screenManager.Load(nextLevel, nextSound);
	}
}
