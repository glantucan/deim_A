using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] private float v;

	public void Move(Vector3 dir) {
		Vector3 displacement = this.v * dir * Time.deltaTime;
		this.transform.position += displacement;
	}
}
