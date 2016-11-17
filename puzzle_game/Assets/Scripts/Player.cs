using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	private Vector3 direction;
	private Rigidbody rb;

	private PlayerInventory playerInventory;
				

			

	[SerializeField] private List<GameObject> groundContacts;

	[SerializeField] private Transform cameraTr;
	private Vector3 cameraPlayerDistance;
	private int cameraAngle;


	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.groundContacts = new List<GameObject>();
		this.cameraPlayerDistance =  this.cameraTr.position - this.transform.position;
		this.cameraAngle = 0;

		playerInventory = this.GetComponent<PlayerInventory>();
	}



	// Update is called once per frame
	void Update () {

		MovePlayer();

		ThrowStones();

		if (Input.GetKeyUp(KeyCode.Q)) {
			if (this.cameraAngle != 270) {
				this.cameraAngle = this.cameraAngle + 90;
			} else {
				this.cameraAngle = 0;
			}
					
			this.cameraPlayerDistance = new Vector3(
				this.cameraPlayerDistance.z,
				this.cameraPlayerDistance.y,
				-this.cameraPlayerDistance.x
			);

			Debug.Log(this.cameraAngle);

		} else if (Input.GetKeyUp(KeyCode.E)) {
			if (this.cameraAngle != 0) {
				this.cameraAngle = this.cameraAngle - 90;
			} else {
				this.cameraAngle = 270;
			}


			this.cameraPlayerDistance = new Vector3(
				-this.cameraPlayerDistance.z,
				this.cameraPlayerDistance.y,
				this.cameraPlayerDistance.x
			);
			Debug.Log(this.cameraAngle);

		}

	}

	void FixedUpdate() {
		// CameraFollow
		this.cameraTr.LookAt(this.transform);
		Vector3 camWantedPosition = this.transform.position + this.cameraPlayerDistance;
		//this.cameraTr.position = camWantedPosition;
		this.cameraTr.position = Vector3.Lerp(this.cameraTr.position, camWantedPosition, 0.05F); 
	}

	void ThrowStones() {
		GameObject stone = playerInventory.GetStone();
		if (stone != null){
			stone.SetActive(true);							  // Vector3.forward
			stone.transform.position = this.transform.position + this.transform.forward;

			StoneMovement stoneControl = stone.GetComponent<StoneMovement>();
			stoneControl.Launch(this.transform.forward + 0.25F * Vector3.up);
		}

	}



	void MovePlayer () {
		if (groundContacts.Count > 0) {
			this.rb.velocity = new Vector3(
				this.rb.velocity.x,
				0F,
				this.rb.velocity.z
			);
			this.rb.useGravity = false;
			this.rb.drag = 8F;
			float xInput = Input.GetAxisRaw("Horizontal");
			float zInput = Input.GetAxisRaw("Vertical");


			if (this.cameraAngle == 0) {
				this.direction = xInput * Vector3.right + zInput * Vector3.forward;
			} else if (this.cameraAngle == 90) {
				this.direction = zInput * Vector3.right - xInput * Vector3.forward;
			} else if (this.cameraAngle == 180) {
				this.direction = -xInput * Vector3.right - zInput * Vector3.forward;
			} else if (this.cameraAngle == 270) {
				this.direction = -zInput * Vector3.right + xInput * Vector3.forward;
			}



			if (this.direction.magnitude != 0) {
				this.rb.velocity = this.direction.normalized * this.speed;
			}


			if (Input.GetKey(KeyCode.Space)) {
				this.rb.velocity = this.rb.velocity + Vector3.up * jumpSpeed;
			}

		} else {
			this.rb.useGravity = true;
			this.rb.drag = 0F;
			float xInput = Input.GetAxisRaw("Horizontal");
			float zInput = Input.GetAxisRaw("Vertical");
			this.direction = xInput * Vector3.right + zInput * Vector3.forward;

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







