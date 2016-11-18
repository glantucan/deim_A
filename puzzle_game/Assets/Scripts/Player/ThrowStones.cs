using UnityEngine;
using System.Collections;

public class ThrowStones : MonoBehaviour {


	private PlayerInventory playerInventory;


	void Start () {
		playerInventory = this.GetComponent<PlayerInventory>();
	}
	

	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			GameObject stone = playerInventory.GetItemFromInventory();
			if (stone != null){
				stone.SetActive(true);							  // Vector3.forward
				stone.transform.position = this.transform.position + this.transform.forward;

				StoneMovement stoneControl = stone.GetComponent<StoneMovement>();
				stoneControl.Launch(this.transform.forward + 0.25F * Vector3.up);
			}
		}
	}
}
