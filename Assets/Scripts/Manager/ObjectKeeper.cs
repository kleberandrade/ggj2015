using UnityEngine;
using System.Collections;

public class ObjectKeeper : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

}
