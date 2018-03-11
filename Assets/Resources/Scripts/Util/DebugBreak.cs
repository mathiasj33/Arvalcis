using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBreak : MonoBehaviour {

	public KeyCode breakKey;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(breakKey)) Debug.Break();
	}
}
