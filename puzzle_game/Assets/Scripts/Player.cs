using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private bool isNearSwitch;
	private GameObject nearestButton;
	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.isNearSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;

		if(this.direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}

		if (isNearSwitch) {
			if (Input.GetKeyUp(KeyCode.Space)) {
				this.PressButton(nearestButton);
			}
		}
	}

	void PressButton(GameObject button) {
		bool isButtonActive = this.SwitchButtonState(button);
		this.PerformAction(button.name, isButtonActive);
	}

	bool SwitchButtonState(GameObject switchButton) {
		Transform buttonLightTr = switchButton.transform.FindChild("ButtonLight");
		Transform buttonGlimmerLightTr = switchButton.transform.FindChild("GlimmerLight");

		bool isButtonActive = buttonLightTr.gameObject.activeSelf;

		buttonLightTr.gameObject.SetActive(!isButtonActive);
		buttonGlimmerLightTr.gameObject.SetActive(!isButtonActive);
		return isButtonActive;
	}

	void PerformAction(string buttonName, bool isButtonActive){
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

	string GetTargetNameSuffix(string name){
		string[] buttonNameSplitted = name.Split('_');
		return buttonNameSplitted[0];
	} 

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Switch") {
			this.nearestButton = other.gameObject;
			this.isNearSwitch = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = null;
			this.isNearSwitch = false;
		}
	}
}







