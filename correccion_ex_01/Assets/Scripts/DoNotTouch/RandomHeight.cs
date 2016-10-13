using UnityEngine;
using System.Collections;

public class RandomHeight : MonoBehaviour {
	[SerializeField] float minHeight;
	[SerializeField] float maxHeight;

	void Awake () {
		this.transform.localScale = new Vector3(
			this.transform.localScale.x,
			Random.Range(minHeight, maxHeight),
			this.transform.localScale.z
		);
		this.transform.position = new Vector3(
			this.transform.position.x,
			this.transform.localScale.y/2,
			this.transform.position.z
		);
	}
	

}
