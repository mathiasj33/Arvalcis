// using UnityEngine;
// using System.Collections.Generic;
// using System.Collections;

// public class EnemyControl : MonoBehaviour {

//     private EnemyAnimationControl animControl;
//     private GameObject player;
//     private PlayerControl playerControl;
//     //private WarpControl warpControl;
//     private Invoker invoker;

//     private UnityEngine.AI.NavMeshAgent agent;
//     private List<Vector3> waypoints = new List<Vector3>();
//     private int wpIndex;

//     void Start () {
//         agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
//         animControl = GetComponent<EnemyAnimationControl>();
//         player = GameObject.Find("Player");
//         playerControl = player.GetComponent<PlayerControl>();
//         //warpControl = player.transform.parent.GetComponent<WarpControl>();
//         invoker = GameObject.Find("Main").GetComponent<Invoker>();

//         foreach(Transform t in transform.Find("Waypoints"))
//         {
//             waypoints.Add(t.position);
//         }
//         if (waypoints.Count > 0)
//         {
//             agent.SetDestination(waypoints[0]);
//             StartCoroutine("SetWalkAnim");
//         }
//     }

//     private IEnumerator SetWalkAnim()
//     {
//         yield return new WaitForSeconds(.5f);
//         animControl.Walk();
//     }

// 	void Update () {
//         ApplyMove();
//         ApplyAttackPlayer();
// 	}

//     private void ApplyMove()
//     {
//         if (waypoints.Count == 0) return;
//         if(agent.remainingDistance <= 1)
//         {
//             wpIndex++;
//             if (wpIndex >= waypoints.Count) wpIndex = 0;
//             agent.SetDestination(waypoints[wpIndex]);
//         }
//     }

//     private void ApplyAttackPlayer()
//     {
//         if (CanSeePlayer())
//         {
//             KillPlayer();
//             //invoker.Invoke(.5f, playerControl.Die);
//             Destroy(this);
//         }
//     }

//     private bool CanSeePlayer()
//     {
//         //if (warpControl.IsWarping) return false;

//         Vector3 eyePos = transform.position + new Vector3(0, 1.8f, 0);

//         Vector3 toPlayer = player.transform.position - eyePos;
//         toPlayer.Normalize();

//         Ray ray = new Ray(eyePos, toPlayer);
//         RaycastHit hit;

//         if (Physics.Raycast(ray, out hit, 20))
//         {
//             if (hit.collider.gameObject.tag != "Player") return false;

//             float angle = Vector3.Angle(toPlayer, transform.forward);
//             float yDistance = player.transform.position.y - transform.position.y;
//             //float angleThreshold = playerControl.Crouched ? 50 : 60;
//             //return angle <= angleThreshold && yDistance < 2;
//             return false;
//         }
//         return false;
//     }

//     private void KillPlayer()
//     {
//         animControl.Shoot();
//     }

//     public void Die()
//     {
//         agent.enabled = false;
//         animControl.PlayDeathAnim();
//         Destroy(this);
//     }
// }