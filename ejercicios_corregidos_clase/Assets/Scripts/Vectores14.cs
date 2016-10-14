using UnityEngine;
using System.Collections;

public class Vectores14 : MonoBehaviour {

	[SerializeField] private GameObject stepPrefab;  
	[SerializeField] private GameObject landingPrefab;  

	// Use this for initialization
	void Start () {
		float stepWidth = 0.25F;
		float stepHeight = 0.20F;
		float landingWidth = 1F;
		float landingHeight = 0.20F;

		Vector3 lastPosition = Vector3.zero;
		int stepCounter = 0;
		while (stepCounter < 20) {
			// Si el contador es multiplo de cinco el resto de stepCounter/5 es 0 =>
			if (stepCounter % 5 == 0) {
				GameObject landingInstance = Object.Instantiate(this.landingPrefab);
				landingInstance.transform.position = lastPosition + stepHeight * Vector3.up 
													- stepWidth * Vector3.right;
				lastPosition = landingInstance.transform.position;
			} else {// Si  no 
				GameObject stepInstance = Object.Instantiate(this.stepPrefab);
				if (stepCounter % 5 == 1) { // escalon siguiente a un descansillo
					stepInstance.transform.position = lastPosition + stepHeight * Vector3.up 
													- landingWidth * Vector3.right;
				} else {
					stepInstance.transform.position = lastPosition + stepHeight * Vector3.up 
													- stepWidth * Vector3.right;
				}
				lastPosition = stepInstance.transform.position;
			}
			stepCounter = stepCounter + 1;
		}
	}

}
