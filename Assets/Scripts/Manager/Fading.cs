using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    public float fadeSpeed = 0.8f;
    private float alpha = 1.0f;
    private int fadeDir = -1;
    private Image image;
    private Color color;

	void Awake () 
    {
        image = GetComponent<Image>();
        color = image.color;
	}
	
	void Update () 
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        color.a = alpha;
        image.color = color;
	}
}
