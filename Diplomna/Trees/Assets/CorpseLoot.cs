using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CorpseLoot : MonoBehaviour {

	private Rect inventoryWindowRect = new Rect(200, 50, 200, 250);
	private bool inventoryWindowShow = false;

	private Dictionary<int, string> lootDictionary = new Dictionary<int, string>() {
		{0, string.Empty},
		{1, string.Empty},
		{2, string.Empty},
		{3, string.Empty},
		{4, string.Empty},
		{5, string.Empty},
	};

	ItemClass itemObject = new ItemClass();

	private Ray mouseRay;
	private RaycastHit rayHit;

	// Use this for initialization
	void Start () {
//		lootDictionary[0] = itemObject.steakItem.name;
//		lootDictionary [1] = itemObject.grassItem.name;
	}
	
	// Update is called once per frame
	void Update () {

		mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetButtonDown ("Fire1")) {
			Physics.Raycast(mouseRay, out rayHit);
			if (rayHit.collider.transform.tag == "Lootable") {
				inventoryWindowShow = true;
			}
		}
	
	}

	void onGUI() {

		if (inventoryWindowShow) {
			inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindowMethod, "Corpse");
		}
	}

	void InventoryWindowMethod (int windowId) {
		GUILayout.BeginArea (new Rect (0, 50, 200, 200));
		
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button (lootDictionary [0], GUILayout.Height (50))) {
			if(lootDictionary[0] != string.Empty) {
				InventoryGUI.inventoryNameDictionary[0] = lootDictionary[0];
			}
		}
		if (GUILayout.Button (lootDictionary [1], GUILayout.Height (50))) {
			if(lootDictionary[1] != string.Empty) {
				InventoryGUI.inventoryNameDictionary[1] = lootDictionary[1];
			}
		}
		if (GUILayout.Button (lootDictionary [2], GUILayout.Height (50))) {
			if(lootDictionary[2] != string.Empty) {
				InventoryGUI.inventoryNameDictionary[2] = lootDictionary[2];
			}
		}

	}
}
