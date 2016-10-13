﻿using UnityEngine;
using System.Collections;

public class AdaptableLadder : MonoBehaviour {
	public GameObject sideRailPrefab;
	public GameObject rungPrefab;
	public GameObject cube;
	public float rungSeparation;

	private int rungNumber;
	private float height;

	void Start () {
		MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
		height = renderer.bounds.size.y;


		GameObject firstSideRail = Object.Instantiate(this.sideRailPrefab);
		Vector3 oldScale1 = firstSideRail.transform.localScale;
		firstSideRail.transform.localScale = new Vector3(oldScale1.x, height, oldScale1.z);
		firstSideRail.transform.position = (this.height/2) * Vector3.up + (this.transform.position.z + 0.05F)*Vector3.forward;

		GameObject secondSideRail = Object.Instantiate(this.sideRailPrefab);
		Vector3 oldScale2 = secondSideRail.transform.localScale;
		secondSideRail.transform.localScale = new Vector3(oldScale2.x, height, oldScale2.z);
		secondSideRail.transform.position = new Vector3(0F, this.height/2, this.transform.position.z + 0.95F);

		rungNumber = Mathf.FloorToInt(height/rungSeparation);

		int rungCount = 0;
		while (rungCount < rungNumber) {
			GameObject rungInstance = Object.Instantiate (this.rungPrefab);
			rungInstance.transform.position = new Vector3 (0F, rungCount*rungSeparation + 0.5F, this.transform.position.z + 0.5F);
			rungCount = rungCount + 1;
		}
	}

}
