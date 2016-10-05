using UnityEngine;
using System.Collections;

public class MRU_rigidbody : MonoBehaviour {

	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		rb.velocity = 5F * Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
