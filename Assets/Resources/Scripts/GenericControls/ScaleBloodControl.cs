using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBloodControl : MonoBehaviour {

	float scale = 3f;
	
	void Update () {
		scale += Time.deltaTime * 10;
		if(scale >= 14) {
			scale = 14f;
			transform.localScale = new Vector3(scale/100, scale/100, scale/100);
			Destroy(this);
		}
		else {
			transform.localScale = new Vector3(scale/100, scale/100, scale/100);
		}
	}
}
