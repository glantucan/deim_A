using UnityEngine;
using System.Collections;

public class TapValveController : MonoBehaviour {
	[SerializeField] Animation valveAnimation;
	[SerializeField] GameObject dropPrefab;
	[SerializeField] Transform tapEndTr;
	[SerializeField] GameObject water;
 	private bool isOpen;

	private void Start() {
		this.isOpen = false;
	}

	private void Update() {
		if (isOpen) {
			GameObject drop = Object.Instantiate(dropPrefab);
			drop.transform.position = this.tapEndTr.position + 
				new Vector3(
					Random.Range(-0.05F, 0.05F),
					Random.Range(-0.05F, 0.05F),
					0
				);
			drop.transform.localScale = new Vector3(1F,1F,1F) * Random.Range(0.02F, 0.14F);

			Rigidbody dropRb = drop.GetComponent<Rigidbody>();
			dropRb.velocity = Vector3.forward * 2F;
			WaterController waterControl = water.GetComponent<WaterController>();
			waterControl.downScale(0.0015F);
		}
	}

	public void OpenValve() {
		this.valveAnimation.Play();
		this.isOpen =  true;
	}
}
