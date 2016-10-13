using UnityEngine;
using System.Collections;

public class Reto : MonoBehaviour {
	[SerializeField] private GameObject sideRail;
	[SerializeField] private GameObject rung;

	[SerializeField] private GameObject cube;
	[SerializeField] private float rungSeparation;

	void Start () {

		MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
		float height = renderer.bounds.size.y;

		GameObject firstSideRail = Object.Instantiate(this.sideRail);
		Vector3 oldScale1 = firstSideRail.transform.localScale;
		firstSideRail.transform.localScale = new Vector3(oldScale1.x, height, oldScale1.z);
		firstSideRail.transform.position = (height/2)*Vector3.up + 15.05F*Vector3.forward;

		GameObject secondSideRail = Object.Instantiate(this.sideRail);
		Vector3 oldScale2 = secondSideRail.transform.localScale;
		secondSideRail.transform.localScale =  new Vector3(oldScale2.x, height, oldScale2.z);
		secondSideRail.transform.position = new Vector3(0F, height/2, 15.95F);

		float currentHeight = rungSeparation; // 0.5F
		while(currentHeight < height){
			GameObject rungInstance = Object.Instantiate (this.rung);
			rungInstance.transform.position = new Vector3 (0F, currentHeight , 15.5F);
			currentHeight = currentHeight + rungSeparation;
		}
	}
}

