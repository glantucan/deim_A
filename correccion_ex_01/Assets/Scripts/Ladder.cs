using UnityEngine;
using System.Collections;

public class LadderWithLandings : MonoBehaviour {
	[SerializeField] private GameObject stairStepPrefab;
	[SerializeField] private GameObject landingPrefab;


	void Start () {
		float stepHeight = 0.25F;
		float stepDepth = 0.2F;

		float landingHeight = 0.25F;
		float landingDepth = 1F;

		int count = 1;
		while (count < 20) {
			if (count % 5 == 0) {
				GameObject landingInstance = GameObject.Instantiate(landingPrefab);
				landingInstance.transform.position = 
					Vector3.up * landingHeight * (count - 1) + Vector3.forward * landingDepth * (count - 1);
			} else {
				GameObject stairStepInstance = GameObject.Instantiate(stairStepPrefab);
				stairStepInstance.transform.position = 
					Vector3.up * stepHeight * (count - 1) + Vector3.forward * stepDepth * (count - 1);
			}
			count = count + 1;
		}
	}
}
