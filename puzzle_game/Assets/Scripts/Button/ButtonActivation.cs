using UnityEngine;
using System.Collections;

public class ButtonActivation : MonoBehaviour {

	private bool isActive;
	[SerializeField] private GameObject buttonLight;
	[SerializeField] private GameObject buttonGlimmerLight;

	[SerializeField] private GameObject target;

	private ITargetAction targetAction;

	private void Start() {
		isActive = false;
		this.targetAction = target.GetComponent<ITargetAction>();
	}

	public void Interact() {
		if (this.isActive) {
			this.DeActivate();
		} else {
			this.Activate();
		}
	}

	private void Activate(){
		buttonLight.SetActive(true);
		buttonGlimmerLight.SetActive(true);
		targetAction.DoAction();
		// Falta realizar la acción del botón
		this.isActive = true;
	}
	private void DeActivate(){
		buttonLight.SetActive(false);
		buttonGlimmerLight.SetActive(false);
		targetAction.UndoAction();
		// Falta deshacer la acción del botón
		this.isActive = false;
	}



}
