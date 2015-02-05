using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {

	public float rotationSpeed;
	public float movementSpeed = 1f;
	public float rotationTime;
	public Transform sightStart;
	public Transform sightEnd;
	public bool colliding;

	// Use this for initialization
	void Start () {
		Invoke ("ChangeRotation", rotationTime);
	}

	void ChangeRotation() {
		if (Random.value > 0.5) {
			rotationSpeed = -rotationSpeed;		
		}
		Invoke ("ChangeRotation", rotationTime);

	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, rotationSpeed * Time.deltaTime));
		transform.position += transform.up * movementSpeed * Time.deltaTime;

		colliding = Physics.Linecast (sightStart.position, sightEnd.position);
		
		if (colliding) {
			transform.localScale = new Vector2 ( transform.localScale.x * -1, transform.localScale.y);
			movementSpeed*= -1;
		}
	}
}





