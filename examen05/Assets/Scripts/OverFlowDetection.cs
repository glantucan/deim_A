using UnityEngine;
using System.Collections;

public class OverFlowDetection : MonoBehaviour {
	[SerializeField] GameObject tapValve;

	private void OnTriggerEnter(Collider other) {
		if ( other.tag == "Water") {
			TapValveController valve = tapValve.GetComponent<TapValveController>();
			valve.OpenValve();
		}
	}
}
