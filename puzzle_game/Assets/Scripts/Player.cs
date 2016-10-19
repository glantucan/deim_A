using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Vector3 direction;

	private Rigidbody rb;

	private bool isNearSwitch;
	private GameObject nearestButton;
	
	// Use this for initialization
	void Start () {
		this.rb = this.GetComponent<Rigidbody>();
		this.isNearSwitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		float xInput = Input.GetAxisRaw("Horizontal");
		float zInput = Input.GetAxisRaw("Vertical");
		this.direction = xInput * Vector3.right + zInput * Vector3.forward;

		if(this.direction.magnitude != 0) {
			this.rb.velocity = this.direction.normalized * this.speed;
		}

		if (isNearSwitch) {
			if (Input.GetKeyUp(KeyCode.Space)) {
				Transform buttonLightTr = nearestButton.transform.FindChild("ButtonLight");
				Transform buttonGlimmerLightTr = nearestButton.transform.FindChild("GlimmerLight");
				// Encontrar el gameobject del mecanismo que queremos activar
				GameObject ramp = GameObject.Find("AnimatedRamp");
				Animation rampAnimation = ramp.GetComponent<Animation>();

				if (buttonLightTr.gameObject.activeSelf) { // Si el boton está activo
					buttonLightTr.gameObject.SetActive(false);
					buttonGlimmerLightTr.gameObject.SetActive(false);
					rampAnimation.Play("hideRamp");
				} else { // si el botón está inactivo
					buttonLightTr.gameObject.SetActive(true);
					buttonGlimmerLightTr.gameObject.SetActive(true);
					rampAnimation.Play("showRamp");
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Switch") {
			this.nearestButton = other.gameObject;
			this.isNearSwitch = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Switch") {
			this.nearestButton = null;
			this.isNearSwitch = false;
		}
	}
}







