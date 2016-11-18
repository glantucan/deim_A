using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	private Vector3 direction;
	private Rigidbody rb;

	[SerializeField] private List<GameObject> groundContacts;

	[SerializeField] private CameraMovement cameraControl;



	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.groundContacts = new List<GameObject>();
	}


	// Update is called once per frame
	void Update () {
		MovePlayer();
	}


	void MovePlayer () {
		int cameraAngle = this.cameraControl.GetCameraAngle();

		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");

		if (cameraAngle == 0) {
			this.direction = xInput * Vector3.right + zInput * Vector3.forward;
		} else if (cameraAngle == 90) {
			this.direction = zInput * Vector3.right - xInput * Vector3.forward;
		} else if (cameraAngle == 180) {
			this.direction = -xInput * Vector3.right - zInput * Vector3.forward;
		} else if (cameraAngle == 270) {
			this.direction = -zInput * Vector3.right + xInput * Vector3.forward;
		}

		if (groundContacts.Count > 0) {
			this.rb.velocity = new Vector3(this.rb.velocity.x, 0F, this.rb.velocity.z);
			this.rb.useGravity = false;
			this.rb.drag = 8F;

			if (this.direction.magnitude != 0) {
				this.rb.velocity = this.direction.normalized * this.speed;
			}

			if (Input.GetKey(KeyCode.Space)) {
				this.rb.velocity = this.rb.velocity + Vector3.up * jumpSpeed;
			}

		} else {
			this.rb.useGravity = true;
			this.rb.drag = 0F;

			this.rb.velocity = this.direction.normalized * this.speed +
								Vector3.up * rb.velocity.y;  
			
		}
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Ground") {
			groundContacts.Add(other.gameObject);
		}
	}	

	void OnTriggerExit(Collider other) {
		if (other.tag == "Ground") {
			groundContacts.Remove(other.gameObject);
		}
	}


}







