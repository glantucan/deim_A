using UnityEngine;
using System.Collections;

public class ButtonDetection : MonoBehaviour {

	private GameObject nearestButton;
	
	// Update is called once per frame
	private void Update () {
		// Buttons activation
		if (nearestButton != null) {
			if (Input.GetKeyUp(KeyCode.F)) {
				ButtonActivation activator = nearestButton.GetComponent<ButtonActivation>();
				activator.Interact();
			}
		}
	}

	private void OnTriggerEnter (Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = other.gameObject;
		}
	}

	private void OnTriggerExit (Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = null;
		}
	}
}
