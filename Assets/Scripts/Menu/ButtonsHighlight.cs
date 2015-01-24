using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonsHighlight : MonoBehaviour {
	private GameObject Btn1, Btn2, Btn3;
	//private Image icon1,icon2,icon3;
	//private Button play, credits, exit;
	public float buttonthreshold =0.2f;
	public float timer = 0.0f;
	public float current;

	// Use this for initialization


	
	
	void Awake ()
	{
	
		//icon1 = GameObject.FindGameObjectWithTag ("Img1").GetComponent<Image>();
		//icon2 = GameObject.FindGameObjectWithTag ("Img1").GetComponent<Image>();
		//icon3 = GameObject.FindGameObjectWithTag ("Img1").GetComponent<Image>();


		Btn1 = GameObject.FindGameObjectWithTag ("b1");
		Btn2 = GameObject.FindGameObjectWithTag ("b2");
		Btn3 = GameObject.FindGameObjectWithTag ("b3");
		current = 3;
	}

	void Start () 
    {
		SwitchIcon(current);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(Input.GetAxisRaw("Vertical") != 0.0f  && timer >= buttonthreshold){
			current+=Input.GetAxisRaw("Vertical");
			if(current > 3.0f) current= 1.0f;
			else if(current < 1.0f) current = 3.0f;
			SwitchIcon(current);
			
		} 
		if (Input.GetButtonDown ("Attack") && timer >= buttonthreshold) {
			ExecuteButton((int)current);
		}
			
	}

	void ExecuteButton(int val){
		var pointer = new PointerEventData(EventSystem.current);

		switch (val){		
		case 3 : { 
				ExecuteEvents.Execute(Btn1, pointer, ExecuteEvents.pointerClickHandler);
			break;}
		case 2 : { 
				ExecuteEvents.Execute(Btn2, pointer, ExecuteEvents.pointerClickHandler);
			break;
		}
		case 1 : { 
				ExecuteEvents.Execute(Btn3, pointer, ExecuteEvents.pointerClickHandler);
			break;
		}	
		}
	}




	void SwitchIcon(float val){
		timer = 0.0f;
		int x = (int)val;
		switch (x){
		case 3 : { 
			ShowIcon1();
			break;}
		case 2 : { 
			ShowIcon2();
			break;
		}
		case 1 : { 
			ShowIcon3 ();
			break;
		}	
		}
	}

	void ShowIcon1()
    {
		var pointer = new PointerEventData(EventSystem.current);
		ExecuteEvents.Execute(Btn1, pointer, ExecuteEvents.pointerEnterHandler);
		ExecuteEvents.Execute(Btn2, pointer, ExecuteEvents.pointerExitHandler);
        ExecuteEvents.Execute(Btn3, pointer, ExecuteEvents.pointerExitHandler);
	}

	void ShowIcon2()
    {
		var pointer = new PointerEventData(EventSystem.current);
		ExecuteEvents.Execute(Btn1, pointer, ExecuteEvents.pointerExitHandler);
		ExecuteEvents.Execute(Btn2, pointer, ExecuteEvents.pointerEnterHandler);
		ExecuteEvents.Execute(Btn3, pointer, ExecuteEvents.pointerExitHandler);
	}


	void ShowIcon3()
    {
		var pointer = new PointerEventData(EventSystem.current);
		ExecuteEvents.Execute(Btn1, pointer, ExecuteEvents.pointerExitHandler);
		ExecuteEvents.Execute(Btn2, pointer, ExecuteEvents.pointerExitHandler);
		ExecuteEvents.Execute(Btn3, pointer, ExecuteEvents.pointerEnterHandler);
	}
}
