using UnityEngine;
using System.Collections;

public class CubeJump : MonoBehaviour {
	[SerializeField] float jumpVel;

	public void Jump() {
		Rigidbody rb = this.GetComponent<Rigidbody>();
		rb.velocity = jumpVel * Vector3.up;
	}
}
