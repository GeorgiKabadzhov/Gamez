using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryGUI : MonoBehaviour {

	private Rect inventoryWindowRect = new Rect(200, 50, 200, 250);
	private bool inventoryWindowToggle = false;

	static public Dictionary<int, string> inventoryNameDictionary = new Dictionary<int,string>() {
		{0, string.Empty},
		{1, string.Empty},
		{2, string.Empty},
		{3, string.Empty},
		{4, string.Empty},
		{5, string.Empty},
		{6, string.Empty},
		{7, string.Empty},
		{8, string.Empty}
	};

	ItemClass itemObject = new ItemClass();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		inventoryWindowToggle = GUI.Toggle (new Rect (80, 50, 100, 50), inventoryWindowToggle, "Inventory");

		if (inventoryWindowToggle) {
			inventoryWindowRect = GUI.Window(0, inventoryWindowRect, InventoryWindowMethod, "Inventory");
		}
	}

	void InventoryWindowMethod(int windowId) {


		//Items

		//Display dictionary
//		inventoryNameDictionary [0] = steakItem.name;
//		inventoryNameDictionary [1] = stoneItem.name;

		GUILayout.BeginArea (new Rect (0, 50, 200, 200));

		GUILayout.BeginHorizontal ();
		GUILayout.Button (inventoryNameDictionary[0], GUILayout.Height (50));
		GUILayout.Button ("Item 2", GUILayout.Height (50));
		GUILayout.Button ("Item 3", GUILayout.Height (50));
		GUILayout.EndHorizontal ();
		
		GUILayout.BeginHorizontal ();

		GUILayout.Button ("Item 4", GUILayout.Height (50));
		GUILayout.Button ("Item 5", GUILayout.Height (50));
		GUILayout.Button ("Item 6", GUILayout.Height (50));
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Button ("Item 7", GUILayout.Height (50));
		GUILayout.Button ("Item 8", GUILayout.Height (50));
		GUILayout.Button ("Item 9", GUILayout.Height (50));
		GUILayout.EndHorizontal ();

//		GUILayout.BeginHorizontal ();
//		GUILayout.Button ("Item 11", GUILayout.Height (50));
//		GUILayout.Button ("Item 12", GUILayout.Height (50));
//		GUILayout.Button ("Item 13", GUILayout.Height (50));
//		GUILayout.EndHorizontal ();
	
		GUILayout.EndArea ();
	}
}
