using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {

//	public Transform Target;
	public GameObject Enemy;
	public GameObject Player;
	public float Range;
	public float Speed;

	// Use this for initialization
	void Start () {
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
		Range = Vector2.Distance (Enemy.transform.position, Player.transform.position);
			
		if (Range <= 8f) {
			//print ("Blizo si");
			Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed,
		                               (transform.position.y - Player.transform.position.y) * Speed);
			rigidbody.velocity = -velocity;
 		}
	}
}
