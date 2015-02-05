using UnityEngine;
using System.Collections;

public class spawningScript : MonoBehaviour {

	public float spawnTime = 5f; 
	public float spawnDelay = 3f;
	public GameObject[] enemies;
	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", spawnDelay, spawnTime);
	
	}
	
	// Update is called once per frame
	void Spawn () {
	
		int enemyIndex = Random.Range (0, enemies.Length);
		Instantiate(enemies[enemyIndex], transform.position, transform.rotation);

	}
}
