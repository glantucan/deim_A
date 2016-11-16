using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	private Vector3 direction;
	private Rigidbody rb;
	private GameObject nearestButton;

	[SerializeField] private GameObject[] inventory;
	private int objectCount;


	[SerializeField] private List<GameObject> groundContacts;

	[SerializeField] private Transform cameraTr;
	private Vector3 cameraPlayerDistance;



	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.inventory = new GameObject[5];
		this.objectCount = 0;
		this.groundContacts = new List<GameObject>();
		this.cameraPlayerDistance =  this.cameraTr.position - this.transform.position;
	}



	// Update is called once per frame
	void Update () {

		MovePlayer();

		RotatePlayer();

		// Buttons activation
		if (nearestButton != null) {
			if (Input.GetKeyUp(KeyCode.F)) {
				this.PressButton(nearestButton);
			}
		}

		ThrowStones();

		if (Input.GetKeyUp(KeyCode.Q)) {
			this.cameraPlayerDistance = new Vector3(
				this.cameraPlayerDistance.z,
				this.cameraPlayerDistance.y,
				-this.cameraPlayerDistance.x
			);

			this.direction = new Vector3( 
				this.direction.z,
				0F,
            	-this.direction.x
            );

		} else if (Input.GetKeyUp(KeyCode.E)) {
			this.cameraPlayerDistance = new Vector3(
				-this.cameraPlayerDistance.z,
				this.cameraPlayerDistance.y,
				this.cameraPlayerDistance.x
			);

			this.direction = new Vector3( 
				-this.direction.z,
				0F,
            	this.direction.x
            );
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
		if (Input.GetMouseButtonUp(0)) {
			if (objectCount > 0){
				GameObject stone = this.inventory[this.objectCount - 1];
				this.inventory[objectCount - 1] = null;
				this.objectCount = this.objectCount - 1;
				stone.SetActive(true);							  // Vector3.forward
				stone.transform.position = this.transform.position + this.transform.forward;

				StoneMovement stoneControl = stone.GetComponent<StoneMovement>();
				stoneControl.Launch(this.transform.forward + 0.25F * Vector3.up);
			}
		}
	}

	void RotatePlayer() {
		// ROTATION:
		// -------------------------------------------------------------------------------------------------------------
		// Create the ray starting at the camera with the direction corresponding to the 2D position
		// of the mouse pointer on the screen.
		Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		// Create a plane, parallel to the ground and at the height of the player gameobject 
		// to intersect the camera ray. This way we avoid inconsitencies produced 
		// by different game object heights in the scene.
		Plane viewPlane = new Plane(Vector3.up, this.transform.position); 	// 1st paramenter is the vector defining orientation of 
																// the plane. 2nd is just a point the plane must include
        // Define a float to hold the distance to the intersection point
        float rayDistance;
        // Cast the ray from the plane and check if there is an intersection
        if (viewPlane.Raycast(mouseRay, out rayDistance)) {
        	// Get the intersection point between the ray and the plane
            Vector3 intersectionPoint = mouseRay.GetPoint(rayDistance);
            // Draw a line in the editor so we cans see the ray and check 
            // whether it's all right
            Debug.DrawLine(mouseRay.origin, intersectionPoint, Color.green);
            // Finally rotate the player so it looks to the intersection point
            //rotator.rotate(intersectionPoint);
            this.transform.LookAt(intersectionPoint);
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
			this.direction = xInput * Vector3.right + zInput * Vector3.forward;

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

		if (other.tag == "Ground") {
			groundContacts.Add(other.gameObject);
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

		if (other.tag == "Ground") {
			groundContacts.Remove(other.gameObject);
		}
	}


}







