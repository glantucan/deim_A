using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	[SerializeField] int damage;

	private void OnCollisionEnter(Collision col) {
		Health theEnemyHealth = col.gameObject.GetComponent<Health>();
		if (theEnemyHealth != null) {
			theEnemyHealth.makeDammage(damage);
		}
	}
}
