using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private bool isNearSwitch;
	
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
				Debug.Log("Se ha activado el botón");
			}
		}

	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Switch") {
			this.isNearSwitch = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Switch") {
			this.isNearSwitch = false;
		}
	}
}







