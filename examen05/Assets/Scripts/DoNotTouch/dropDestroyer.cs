using UnityEngine;
using System.Collections;

public class dropDestroyer : MonoBehaviour {

	private void OnTriggerEnter(Collider col) {
		
		if (col.tag == "Drop") {
			Object.Destroy(col.gameObject);
		}
	}
}
