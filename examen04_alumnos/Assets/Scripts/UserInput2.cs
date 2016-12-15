using UnityEngine;
using System.Collections;

public class UserInput2 : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.P)) {
			PlayerMovement mover = this.GetComponent<PlayerMovement>();
			mover.Move (this.transform.right);
		} 

		if (Input.GetKey(KeyCode.L)) {
			PlayerMovement mover = this.GetComponent<PlayerMovement>();
			mover.Move (-this.transform.right);
		}
			
		if (Input.GetKeyDown(KeyCode.Comma)) {
			ShootControl mover = this.GetComponent<ShootControl>();
			mover.Shoot();
		}
	}
}
