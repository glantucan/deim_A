using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private GameObject nearestButton;

	[SerializeField] private GameObject[] inventory;
	private int objectCount;
	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.inventory = new GameObject[5];
		this.objectCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;

		if (this.direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}

		if (nearestButton != null) {
			if (Input.GetKeyUp(KeyCode.Space)) {
				this.PressButton(nearestButton);
			}
		}

		if (Input.GetMouseButtonUp(0)) {
			if (objectCount > 0){
				GameObject stone = this.inventory[this.objectCount - 1];
				this.inventory[objectCount - 1] = null;
				this.objectCount = this.objectCount - 1;
				stone.SetActive(true);							  // Vector3.forward
				stone.transform.position = this.transform.position + this.transform.forward;

				StoneMovement stoneControl = stone.GetComponent<StoneMovement>();
				stoneControl.Launch(this.transform.forward);
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
		}

		if (other.tag == "Pickable") {
			this.addItemToInventory(objectCount, inventory, other.gameObject);
		}
	}

	void addItemToInventory(int itemCount, GameObject[] anyInventory, GameObject item) {
		if (itemCount < anyInventory.Length) {
			item.SetActive(false);
			anyInventory[objectCount] = item;
			objectCount = objectCount + 1;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = null;
		}
	}
}







