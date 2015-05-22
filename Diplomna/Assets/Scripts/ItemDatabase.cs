using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	int sodaValue = 0;
	int appleValue = 0;
	public List<Item> items = new List<Item>(); 
	// Use this for initialization
	void Start () {
		items.Add (new Item ("A_Armor04", 0, "NiceArmor", 10, 10, 1, Item.ItemType.Clothes));	
		items.Add (new Item ("A_Armor05", 1, "Better Armor", 10, 10, 1, Item.ItemType.Clothes));
		items.Add (new Item ("P_Red03", 2, "But drinking is always better", 20, 10, 1, Item.ItemType.Consumable)); 
		items.Add (new Item ("I_C_Cherry", 3, "Eating is important for surviving!", 10, 0, 1, Item.ItemType.Consumable));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
