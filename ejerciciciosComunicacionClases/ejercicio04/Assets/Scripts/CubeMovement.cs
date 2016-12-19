using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour {
	private GameObject target;
	private Vector3 finalPosition;
	private bool isMoving;
	[SerializeField] private float v;
	private Vector3 direction;


	// Use this for initialization
	private void Awake () {
		this.isMoving = false;
	}
	
	// Update is called once per frame
	private void Update () {
		if (this.isMoving) {
			Vector3 displacement = v * direction * Time.deltaTime; 
			Vector3 distance = finalPosition - this.transform.position;

			if (distance.magnitude > displacement.magnitude) {
				this.transform.position += displacement;
			} else  {
				this.transform.position = finalPosition;
				isMoving = false;
				CubeMovement targetMovement = this.target.GetComponent<CubeMovement>();
				targetMovement.StartMovement();
			}
		}
	}

	public void SetTarget(GameObject theTargetCube) {
		this.target = theTargetCube;
		direction = (theTargetCube.transform.position - this.transform.position).normalized;
		this.finalPosition = theTargetCube.transform.position - 1F * direction;
	}

	public void StartMovement() {
		this.isMoving = true;
	}
}
