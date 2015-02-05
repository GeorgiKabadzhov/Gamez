using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll) {
				if (coll.gameObject.tag == "enemyRubbit") {
						EnemyHealth.curHealthEn -= 10;
						if (EnemyHealth.curHealthEn == 0) {
								Destroy (coll.gameObject);
						}
			
						//		this.GetComponent<PlayerHealth>().curHealth -= 1;
				} else if (coll.gameObject.tag == "Player") {
						PlayerHealth.curHealth -= 10; 
						if (PlayerHealth.curHealth == 0) {
								Destroy (coll.gameObject);
						}
				}
		}
}
