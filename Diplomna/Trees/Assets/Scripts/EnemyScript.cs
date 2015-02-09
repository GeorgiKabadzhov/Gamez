using UnityEngine;
using System.Collections;
public class EnemyScript : MonoBehaviour {
	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float Xdif;
	private float Ydif;
	public float speed;
	private int Wall;
	public float distance;
	public int Health;
	public int SpikeyGiveDmg = 40;
	public bool colliding;
	public Transform sightStart;
	public Transform sightEnd;
	void Start (){

	}
	public void OnTriggerEnter2D(Collider2D other ){
		if (other.tag == "Player"){
			PlayerHealth.curHealth -= SpikeyGiveDmg;
		}
	}
	void Update () {
		int direction;

		rigidbody.velocity = new Vector2 (speed,rigidbody.velocity.y);
		colliding = Physics.Linecast (sightStart.position, sightEnd.position);
		
		
	/*	if (colliding) {
			transform.localScale = new Vector2 ( transform.localScale.x * -1, transform.localScale.y);
			speed*= -1;
		} */

		distance = Vector2.Distance (Player, transform.position);
		Player = GameObject.Find("Trees").transform.position;
		if (distance < 10) {
			Xdif = Player.x - transform.position.x;
			Ydif = Player.y - transform.position.y;
			PlayerDirection = new Vector2 (Xdif, Ydif);
			if (!Physics2D.Raycast (transform.position, PlayerDirection, 5, Wall)) {
				rigidbody.AddForce (PlayerDirection.normalized * speed);
			}
		}
	}
}