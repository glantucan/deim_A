using UnityEngine;
using System.Collections;

public class UserInput1 : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.Q)) {
			PlayerMovement mover = this.GetComponent<PlayerMovement>();
			mover.Move (-this.transform.right);
		} 

		if (Input.GetKey(KeyCode.A)) {
			PlayerMovement mover = this.GetComponent<PlayerMovement>();
			mover.Move (this.transform.right);
		}
			
		if (Input.GetKeyDown(KeyCode.Z)) {
			ShootControl mover = this.GetComponent<ShootControl>();
			mover.Shoot();
		}
	}
}
