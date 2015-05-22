using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotsScript : MonoBehaviour, IPointerDownHandler, IDragHandler/*, IPointerEnterHandler*/  {
	
	public Item item;
	Image itemImage;
	public int slotNumber;
	Inventory inventory;
	Player player;

	Text itemAmount;
	
	// Use this for initialization
	void Start () {
		itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
		inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		itemImage = gameObject.transform.GetChild(0).GetComponent<Image> ();	
	}
	
	// Update is called once per frame
	void Update () {

		itemAmount.enabled = false;

		if (inventory.Items[slotNumber].itemName != null) {
//			item = inventory.Items[slotNumber];
			itemImage.enabled = true;
			itemImage.sprite = inventory.Items[slotNumber].itemIcon;

			if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable) {
				itemAmount.enabled = true;
				itemAmount.text = "" + inventory.Items[slotNumber].itemValue;
			}

		} else {
			itemImage.enabled = false;
		}
		
	}
	
	public void OnPointerDown(PointerEventData data) {
		Debug.Log (item);


		if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable) {
			inventory.Items[slotNumber].itemValue--;
			if (inventory.Items[slotNumber].itemID == 2 && GameManager.sodaCounter > 0) {
				GameManager.sodaCounter--;
				Player.food += Player.pointsPerFood;

			} else if (inventory.Items[slotNumber].itemID == 3 && GameManager.foodCounter > 0) {
				GameManager.foodCounter--;
				Player.food += Player.pointsPerSoda;

			}
			if (inventory.Items[slotNumber].itemValue == 0) {
				inventory.Items[slotNumber] = new Item();
				itemAmount.enabled=false;
			}
		}

		if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
			inventory.Items[slotNumber] = inventory.thedraggedItem;
			inventory.closeDraggedItem();
		} else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null) {
			inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
			inventory.Items[slotNumber] = inventory.thedraggedItem;
			inventory.closeDraggedItem();
		}
	}
	/*
	public void OnPointEnter(PointerEventData data) {
		if (inventory.Items [slotNumber].itemName == null) {
			Debug.Log (inventory.Items[slotNumber].itemDesc);
		}
	}
	*/
	
	public void OnDrag(PointerEventData data) {
		if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable) {
			inventory.Items[slotNumber].itemValue++;
		}

		if (inventory.Items [slotNumber].itemName != null) {
			inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
			inventory.Items[slotNumber] = new Item();


			itemAmount.enabled = false;
		}
	}
}







