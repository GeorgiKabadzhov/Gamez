using UnityEngine;
using System.Collections;


public class EnemyHealth : MonoBehaviour {
	
	
	public int maxHealthEn = 10;
	public static int curHealthEn = 10;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		AdjustCurrentHealth(0);
	}
	
	void OnGUI() {
		
		GUI.Box (new Rect (10, 40, healthBarLength, 20), curHealthEn + "/" + maxHealthEn);
		
		
	}
	
	
	public void AdjustCurrentHealth(int adj) {
		curHealthEn -= adj;
		
		if(curHealthEn < 0)
			curHealthEn = 0;
		
		if (curHealthEn > maxHealthEn)
			curHealthEn  = maxHealthEn;
		
		if (maxHealthEn < 1)
			maxHealthEn = 1;   

		healthBarLength = (Screen.width / 2) * (curHealthEn / (float)maxHealthEn);
		
		
	}
} 