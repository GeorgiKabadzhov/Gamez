using UnityEngine;
using System.Collections;

public class ItemClass : MonoBehaviour {

	static public Texture2D steakIcon;
	static public Texture2D stoneIcon;
	static public Texture2D grassIcon;

	public ItemCreatorClass steakItem = new ItemCreatorClass (0, "Steak", null, "Good ol' mandja");
	public ItemCreatorClass stoneItem = new ItemCreatorClass (1, "Stone", null, "Good for Hammer!");
	public ItemCreatorClass grassItem = new ItemCreatorClass (2, "Grass", null, "It's illegal to smoke it.");


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public class ItemCreatorClass {
		
		int id;
		string name;
		Texture2D icon;
		string description;
		
		public ItemCreatorClass(int ide, string nam, Texture2D ico, string des) {
			id = ide;
			name = nam;
			icon = ico;
			description = des;
		}
		
	}
}
