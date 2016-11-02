using UnityEngine;
using System.Collections;

public class StoneMovement : MonoBehaviour {

	[SerializeField] private float v;
	private Rigidbody rb;
	private Collider col;

	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.col = this.GetComponent<Collider>();
	}

	void Update() {
		/*if ( this.rb.velocity == Vector3.zero) {  //Esto también valdría */
		if ( this.rb.velocity.magnitude == 0F) {
			this.rb.useGravity = false;
			this.col.isTrigger = true;
		}
	}

	public void Launch(Vector3 launchDirection) {
		this.rb.useGravity = true;
		this.col.isTrigger = false;
		this.rb.velocity = launchDirection.normalized * this.v;
	}
}
