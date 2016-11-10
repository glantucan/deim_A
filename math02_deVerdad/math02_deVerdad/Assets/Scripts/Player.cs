using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private float v;
	[SerializeField] private Transform[] wayPoints;
	private Transform currentTarget;
	private int currentIndex;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		this.currentIndex = 0;
		this.currentTarget = SetNewTarget(this.wayPoints, this.currentIndex);
		this.direction = this.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 distance = this.currentTarget.position - this.transform.position;

		if (distance.magnitude >= this.v * Time.deltaTime) {
			Vector3 displacement = this.direction * this.v * Time.deltaTime;
			this.transform.position = this.transform.position + displacement;
		} else {
			if (this.currentIndex < wayPoints.Length - 1) {
				this.currentIndex++;
			} else {
				this.currentIndex = 0;
			}
			this.currentTarget = SetNewTarget(this.wayPoints, this.currentIndex);
			this.direction = this.transform.forward;
		}
	}

	Transform SetNewTarget(Transform[] targets, int index) {
		Transform newTarget = targets[index];
		this.transform.LookAt(newTarget);
		return newTarget;
	}
}
