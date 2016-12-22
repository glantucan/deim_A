using UnityEngine;
using System.Collections;

public class WaterController : MonoBehaviour {

	public void Scale(float scaleChange) {
		transform.localScale = transform.localScale + Vector3.up*scaleChange;
	}
	public void downScale(float scaleChange) {
		transform.localScale = transform.localScale - Vector3.up*scaleChange;
	}
}
