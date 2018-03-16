using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakedownControl : MonoBehaviour {

    private PlayerAnimationControl animControl;
    private Invoker invoker;

    void Start() {
        animControl = GetComponent<PlayerAnimationControl>();
        invoker = GameObject.Find("Main").GetComponent<Invoker>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animControl.Takeout();
            invoker.Invoke(.25f, () => {
                Ray ray = new Ray(transform.position + new Vector3(0, 1.5f, 0), transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1f) && hit.transform.gameObject.tag.Equals("Enemy")) {
                    var enemyAnimControl = hit.transform.gameObject.GetComponent<EnemyAnimationControl>();
                    Vector3 dir = hit.transform.position - transform.position;
                    enemyAnimControl.PlayDeathAnim(hit.point, dir.normalized / 50);
                }
            });
        }
    }
}