using UnityEngine;
using System.Collections;

public class ButtonsClick : MonoBehaviour {


	public void CreditsClick(){
		Application.LoadLevel("Credits");
	}
	public void StartGame(){
		Application.LoadLevel("Credits");
	}
	public void Exit(){
		Application.Quit();
	}
}
