using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LookAtCamera : MonoBehaviour
{
    public PlayerInput playerInput;
    public Text textName;
    private Camera sourceCamera;
    
    void Start()
    {
        sourceCamera = Camera.main;
        textName.text = string.Format("Player {0}", playerInput.GetControlNumber);
    }

    void Update()
    {
        if (sourceCamera != null)
            transform.rotation = sourceCamera.transform.rotation;
    }
}
