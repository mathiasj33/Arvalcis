using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakedownControl : MonoBehaviour {

	private PlayerAnimationControl animControl;
	private Invoker invoker;

	void Start () {
		animControl = GetComponent<PlayerAnimationControl>();
		invoker = GameObject.Find("Main").GetComponent<Invoker>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)) {
			animControl.Punch();
			invoker.Invoke(.25f, () => {
				GameObject.Find("Alien").GetComponent<EnemyAnimationControl>().PlayDeathAnim(Vector3.forward/20);
			});
		}
	}
}
