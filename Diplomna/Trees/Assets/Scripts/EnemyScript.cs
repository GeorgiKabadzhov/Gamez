using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float velocity = 1f;

	public Transform sightStart;
	public Transform sightEnd;

	public bool colliding;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int direction;

		rigidbody.velocity = new Vector2 (velocity, rigidbody.velocity.y); 
		colliding = Physics.Linecast (sightStart.position, sightEnd.position);


		if (colliding) {
			transform.localScale = new Vector2 ( transform.localScale.x * -1, transform.localScale.y);
			velocity*= -1;
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.magenta;

		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Player") {
			PlayerHealth.curHealth -= 10; 
			if (PlayerHealth.curHealth == 0) {
				Destroy (coll.gameObject);
			}
		}
	}
}