using UnityEngine;
using System.Collections;

public class WaterDrop : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		//if (other.tag == "Water") {
			WaterController water = other.GetComponent<WaterController>();
			if (water != null) {
				water.Scale(0.01F);
			}
		//}
	}
}
