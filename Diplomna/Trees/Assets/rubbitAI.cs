using UnityEngine;
using Pathfinding;
using System.Collections;

	[RequireComponent (typeof (Rigidbody))]
	[RequireComponent (typeof (Seeker))]
public class rubbitAI : MonoBehaviour {
	public Transform Steak;

	public Transform target;

	public float updateRate = 2f;

	private Seeker seeker;
	private Rigidbody rb;

	//the calculate path
	public Path path;

	//The AI's speed per second
	public float speed = 300f;
	public ForceMode fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	//the max distance from AI to a waypoint to it to continue to the next waypoint
	public float nextWaypointDistance = 3;

	private int currentWaypoint = 0;

	void Start () {
		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody>();

		if (target == null) {
			Debug.LogError("No player found");
			return;
		}

		seeker.StartPath (transform.position, target.position, OnPathComplete);
	
		StartCoroutine(UpdatePath ());
	}

	IEnumerator UpdatePath() {
		if (target == null) {
			//TODO: insert a player search here.
			return false;
		}
		seeker.StartPath (transform.position, target.position, OnPathComplete);
		yield return new WaitForSeconds(1f/updateRate);
		StartCoroutine(UpdatePath ());
	}

	public void OnPathComplete (Path p) {
		//Debug.Log ("We got a path. Error? " + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate() {
		if (target == null) {
			//TODO: insert a player search here.
			return;
		}

		//TODO: always look at player?

		if (path == null)
			return;

		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;

		//	Debug.Log ("end of path reached");
			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		//Direction to the next waypoint;
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized; 
		dir *= speed * Time.fixedDeltaTime;

		//Moving the AI
		rb.AddForce (dir, fMode);

		float dist = Vector2.Distance (transform.position, path.vectorPath [currentWaypoint]);
		if (dist < nextWaypointDistance) {
			currentWaypoint++;
			return;
		}


		/*if (EnemyHealth.curHealthEn == 0) {
			Destroy (gameObject);
			Instantiate (Steak, transform.position, Quaternenion.identity);
		}*/
	}

	void OnCollisionEnter(Collision coll) {
			//	n = 0;
		if (coll.gameObject.tag == "Player") {
					//	n = 1;
	//		print ("Pipash Zaeka");
					//	onAttack();
					if (PlayerHealth.curHealth == 0) {
							Destroy (coll.gameObject);
					}
					//		this.GetComponent<PlayerHealth>().curHealth -= 1;
					//	n = 0;
		}
	}
}
