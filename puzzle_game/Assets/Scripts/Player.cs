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
				if (this.IsChildActive(nearestButton, "ButtonLight") ==  false) {
					this.ActivateChild(nearestButton, "ButtonLight");
					this.ActivateChild(nearestButton, "GlimmerLight");
					// Y activar la rampa
				} else {
					this.DeactivateChild(nearestButton, "ButtonLight");
					this.DeactivateChild(nearestButton, "GlimmerLight");
					// Y desactivar la rampa
				}

			}
		}

	}

	bool IsChildActive(GameObject parentGO, string childName) {
		Transform childTr = parentGO.transform.FindChild(childName);
		GameObject child = childTr.gameObject;
		return child.activeSelf;
	}

	void ActivateChild(GameObject parentGO, string childName) {
		Transform childTr = parentGO.transform.FindChild(childName);
		GameObject child = childTr.gameObject;
		child.SetActive(true);
		Debug.Log("Encendiendo la luz " + childName);
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







