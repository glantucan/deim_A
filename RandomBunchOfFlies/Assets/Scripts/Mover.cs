using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	private float v;
	private Vector3 direction;

	// Use this for initialization
	private void Start () {
		v = 4F;
		direction = new Vector3( Random.Range(-1F, 1F), Random.Range(-1F, 1F), Random.Range(-1F, 1F));
		//		Random.onUnitSphere;
	}
	
	// Update is called once per frame
	private void Update () {
		Vector3 displacement = v*direction.normalized*Time.deltaTime;
		this.transform.position += displacement;
	}

	public void changeDirection() {
		direction = Random.onUnitSphere;

	}
}
