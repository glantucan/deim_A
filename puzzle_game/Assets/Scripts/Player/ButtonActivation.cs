using UnityEngine;
using System.Collections;

public class ButtonActivation : MonoBehaviour {

	private GameObject nearestButton;
	
	// Update is called once per frame
	private void Update () {
		// Buttons activation
		if (nearestButton != null) {
			if (Input.GetKeyUp(KeyCode.F)) {
				this.PressButton(nearestButton);
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

	private void PressButton(GameObject button) {
		bool isButtonActive = this.SwitchButtonState(button);
		this.PerformAction(button.name, isButtonActive);
	}

	private bool SwitchButtonState(GameObject switchButton) {
		Transform buttonLightTr = switchButton.transform.FindChild("ButtonLight");
		Transform buttonGlimmerLightTr = switchButton.transform.FindChild("GlimmerLight");

		bool isButtonActive = buttonLightTr.gameObject.activeSelf;

		buttonLightTr.gameObject.SetActive(!isButtonActive);
		buttonGlimmerLightTr.gameObject.SetActive(!isButtonActive);
		return isButtonActive;
	}

	private void PerformAction(string buttonName, bool isButtonActive){
		string targetSuffix =  this.GetTargetNameSuffix(buttonName);
		string targetName = "Animated" + targetSuffix;
		GameObject target = GameObject.Find(targetName);
		Animation targetAnimation = target.GetComponent<Animation>();
		if (isButtonActive) {
			targetAnimation.Play("hide" + targetSuffix);
		} else {
			targetAnimation.Play("show" + targetSuffix);
		}
	}

	private string GetTargetNameSuffix(string name){
		string[] buttonNameSplitted = name.Split('_');
		return buttonNameSplitted[0];
	} 
}
