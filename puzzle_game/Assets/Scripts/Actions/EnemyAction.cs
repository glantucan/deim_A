using UnityEngine;
using System.Collections;

public class EnemyAction : MonoBehaviour, ITargetAction {

	[SerializeField] float vel;
	private GameObject player; 
	private Vector3 direction;

	
	// Update is called once per frame
	private void Update () {
		if (player != null ) {
			Vector3 distance = player.transform.position - this.transform.position;
			direction = distance.normalized;
			Vector3 displacement = direction * vel * Time.deltaTime; 
			this.transform.position = this.transform.position + displacement;
		}
	}

	public void DoAction(GameObject aPlayer) {
		this.player = aPlayer;
	}

	public void UndoAction() {
		this.player = null;
	}
}
