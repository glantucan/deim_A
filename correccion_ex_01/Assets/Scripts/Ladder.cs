using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	public GameObject sideRailPrefab;
	public GameObject rungPrefab;
	public float rungSeparation;
	public float rungNumber;
	public float height;

	void Start () {


		GameObject firstSideRail = Object.Instantiate(this.sideRailPrefab);
		firstSideRail.transform.position = (this.height/2) * Vector3.up + 0.05F*Vector3.forward;

		GameObject secondSideRail = Object.Instantiate(this.sideRailPrefab);
		secondSideRail.transform.position = new Vector3(0F, this.height/2, 0.95F);

		int rungCount = 0;
		while (rungCount < rungNumber) {
			GameObject rungInstance = Object.Instantiate (this.rungPrefab);
			rungInstance.transform.position = new Vector3 (0F, rungCount*rungSeparation + 0.5F, 0.5F);
			rungCount = rungCount + 1;
		}

	}
}

