using UnityEngine;
using System.Collections;

public class spawningScript : MonoBehaviour {
	
	public Transform prefab;
	
	public IEnumerator Do() {
		yield return new WaitForSeconds(5);    
		// code to be executed after 5 secs
	}
	
	public void Awake() {
		InvokeRepeating ("Spawn", 0, 5);
	//	yield return StartCoroutine("Do");
		
	}

	public void Spawn() {
		Instantiate (prefab);
	}
}
