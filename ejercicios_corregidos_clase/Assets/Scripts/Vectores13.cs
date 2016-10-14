using UnityEngine;
using System.Collections;

public class Vectores13 : MonoBehaviour {

	[SerializeField] private GameObject whiteStepPrefab;  
	[SerializeField] private GameObject darkStepPrefab;  

	// Use this for initialization
	void Start () {
		int stepCounter = 0;
		while (stepCounter < 20) {
			// Si el contador es par (multiplo de dos) el resto de stepCounter/2 es 0 =>
			if (stepCounter % 2 == 0) {
				GameObject whiteStepInstance = Object.Instantiate(this.whiteStepPrefab);
				whiteStepInstance.transform.position = (Vector3.up * 0.2F + Vector3.right * 0.25F) * stepCounter;
			} else {// Si el contador es impar (no multiplo de dos) el resto de stepCounter/2 no es 0 =>
				GameObject darkStepInstance = Object.Instantiate(this.darkStepPrefab);
				darkStepInstance.transform.position = (Vector3.up * 0.2F + Vector3.right * 0.25F) * stepCounter;
			}
			stepCounter = stepCounter + 1;
		}
	}

}
