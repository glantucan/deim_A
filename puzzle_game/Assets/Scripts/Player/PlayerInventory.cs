using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour {

	[SerializeField] private GameObject[] inventory;
	private int objectCount;


	// Use this for initialization
	private void Start () {
		this.inventory = new GameObject[5];
		this.objectCount = 0;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Pickable") {
			this.AddItemToInventory(this.objectCount, this.inventory, other.gameObject);
		}
	}

	private void AddItemToInventory(int itemCount, GameObject[] anyInventory, GameObject item) {
		if (itemCount < anyInventory.Length) {
			item.SetActive(false);
			anyInventory[objectCount] = item;
			this.objectCount = this.objectCount + 1;
		}
	}

	public GameObject GetItemFromInventory() {
		GameObject stone = null;
		if (this.GetObjectCount() > 0) {
			stone = this.inventory[this.objectCount - 1];
			this.inventory[objectCount - 1] = null;
			this.objectCount = this.objectCount - 1;
		}
		return stone;
	}

	public int GetObjectCount() {
		return this.objectCount;
	}
}
