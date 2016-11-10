using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private float v;
	[SerializeField] private Transform[] wayPoints;
	private Vector3 direction;
	private Vector3 distance;
	private float distMin; 
	private Transform destiny;
	private int index;

	// ...

	void Start () {
		index = 0;
		destiny = wayPoints[index];
		distance =  destiny.position - this.transform.position;
		direction = distance.normalized;
	}

	void Update () {

		distance =  destiny.position - this.transform.position;
		distMin = v * Time.deltaTime;
		if ( distance.magnitude > distMin) {
			Vector3 displacement = v * direction * Time.deltaTime;
			this.transform.position = this.transform.position + displacement;
		} else {
			this.transform.position = destiny.position;

			if(index < wayPoints.Length - 1) {
				index = index + 1;
			} else {
				index = 0;
			}

			destiny = wayPoints[index];
			distance =  destiny.position - this.transform.position;
			direction = distance.normalized;

		}

		
	}

}
