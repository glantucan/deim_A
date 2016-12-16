using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] int health;

	public void makeDammage( int dam ){
		this.health -= dam;
		Debug.Log ("El " + this.name + " ahora tiene " + health + " puntos de vida.");
	}
}
