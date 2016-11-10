using UnityEngine;
using System.Collections;

public class Vectores24 : MonoBehaviour {
	[SerializeField] private float vMin;
	[SerializeField] private float vMax;

	private Vector3 velocity;
	
	// Use this for initialization
	void Start () {
		this.velocity = Random.onUnitSphere * Random.Range(this.vMin, this.vMax);
		Debug.Log("Sphere volocity: " + this.velocity);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 displacement = this.velocity * Time.deltaTime;
		this.transform.position = this.transform.position  + displacement;
	}
}
