using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {
	
	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items  = new List<Item>();
	public GameObject slots;
	ItemDatabase database;
	int x = -45; 
	int y = 33;
	
	public GameObject draggedItemGameObject;
	public bool draggingItem = false;
	public Item thedraggedItem;
	public int indexOfDraggedItem;

	/*
	public void OnDisable() {
		foodCounter = Items[3].itemValue;
		sodaCounter = Items [2].itemValue;
	} */

	public void showDraggedItem(Item item, int slotNumber) {
		indexOfDraggedItem = slotNumber;
		draggedItemGameObject.SetActive (true);
		thedraggedItem = item;
		draggingItem = true;
		draggedItemGameObject.GetComponent<Image> ().sprite = item.itemIcon;
		
	}
	
	public void closeDraggedItem() {
		draggingItem = false;
		draggedItemGameObject.SetActive (false);
	}
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Inventory start called");
		int Slotamount = 0;

		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
		
		for (int i = 0; i < 3; i++) {
			for (int k = 0; k <4 ; k++) {
				GameObject slot = (GameObject)Instantiate(slots);
				slot.GetComponent<SlotsScript>().slotNumber = Slotamount;
				Slots.Add (slot);
				Items.Add(new Item());
				slot.transform.parent = this.gameObject.transform;
				slot.GetComponent<RectTransform>().localPosition = new Vector3(x,y,0);
				x = x + 30;
				if (k == 3) {
					x = -45;
					y = y - 33;
				}
				Slotamount++;
			}
		}

		for (int i = 0; i < GameManager.foodCounter; i++) {
			addItem(3, true);
		} 
		
		for (int i = 0; i < GameManager.sodaCounter; i++) {
			addItem (2, true);
		}

//		addItem (0);
//		addItem (1);

//		addItem (2);
//		addItem (2);
//		addItem (3);
//		addItem (3);
//		addItem (3);

		Debug.Log (Items[0].itemName);
		
	}
	
	void Update() {
		if (draggingItem) {
			//Vector3 posi = (Input.mousePosition = GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
			Vector3 posi = Input.mousePosition;
			posi -= GameObject.FindWithTag("Canvas").GetComponent<RectTransform>().localPosition;
			draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x +15, posi.y - 15, posi.z);
		}
	}

	public void checkIfItemExist(int itemID, Item item) {
		for (int i = 0; i < Items.Count; i++) {
			if(Items[i].itemID == itemID) {
				Items[i].itemValue = Items[i].itemValue + 1;

				break;
			} else if (i == Items.Count - 1) {
				addItemAtEmptySlot(item);
			}
		}
	}

	public void addItem(int id, bool init) {
		/* increase global counters for soda and food*/


		if (!init) {
			if(id == 2) {
				GameManager.sodaCounter++;
			} else if (id == 3) {
				GameManager.foodCounter++;
			}
		}
		Debug.Log (database.items.Count);
		for (int i = 0; i<database.items.Count; i++) {
			if(database.items[i].itemID == id) {
		//		Debug.Log(database.items.itemName);
				Item item = database.items[i];

//				database.items[i].itemValue = itemCounter;

				if(database.items[i].itemType == Item.ItemType.Consumable) {
					checkIfItemExist(id, item);
					break;
				} else {
					addItemAtEmptySlot(item);
				}
			}
		}
	}
	
	void addItemAtEmptySlot(Item item) {
		for (int i = 0; i<Items.Count; i++) {
			if(Items[i].itemName == null) {
				Items[i] = item;
				break;
			}
		}
	}

}
