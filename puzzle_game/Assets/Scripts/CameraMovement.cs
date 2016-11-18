using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Vector3 cameraPlayerDistance;
	private int cameraAngle;

	[SerializeField] private Transform playerTr;



	// Use this for initialization
	private void Start () {
		this.cameraPlayerDistance =  this.transform.position - this.playerTr.position;
		this.cameraAngle = 0;
	}
	
	// Update is called once per frame
	private void Update () {

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

	private void FixedUpdate() {
		// CameraFollow
		this.transform.LookAt(this.playerTr);
		Vector3 camWantedPosition = this.playerTr.position + this.cameraPlayerDistance;
		//this.cameraTr.position = camWantedPosition;
		this.transform.position = Vector3.Lerp(this.transform.position, camWantedPosition, 0.05F); 
	}


	public int GetCameraAngle() {
		return this.cameraAngle;
	}
}
