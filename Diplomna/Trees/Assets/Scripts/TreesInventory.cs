using UnityEngine;
using System.Collections;

public class TreesInventory : MonoBehaviour {

	public static GameObject[] Inventory;
	public static int arrPosit = 0;
	public static bool founditem = true;

	void Start() {
		Inventory = new GameObject[20];
	}

	void Update() {
	//	AddItem ();
	}

}
