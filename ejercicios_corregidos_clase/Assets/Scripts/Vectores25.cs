using UnityEngine;
using System.Collections;

public class Vectores25 : MonoBehaviour {
	[SerializeField] private Transform sphereTr;

	private int frameCounter;

	private Vector3 firstPosition;

	private Vector3 measuredVel;

	void Start(){
		this.frameCounter = 1;
	}

	void Update () {
		if (this.frameCounter == 20) {
			this.firstPosition = this.sphereTr.position;
		} else if (this.frameCounter == 21) {
			Vector3 travelledDistance = this.sphereTr.position - this.firstPosition;
			measuredVel = travelledDistance / Time.deltaTime;
		} else if (this.frameCounter == 60) {
			Debug.Log("measured velocity: " + measuredVel);
		}

		this.frameCounter = this.frameCounter + 1;
	}
}
