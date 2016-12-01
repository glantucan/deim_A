using UnityEngine;
using System.Collections;

public class SpheresCreator : MonoBehaviour {

	[SerializeField] private GameObject prefab;
	private GameObject[] spheres;
	private float timer;

	private void Start () {
		this.spheres = new GameObject[20];
		int counter = 0;
		while (counter < 20) {
			this.spheres[counter] = Object.Instantiate(prefab);
			this.spheres[counter].transform.position = new Vector3(
				Random.Range(-5F, 5F),
				Random.Range(-5F, 5F),
				Random.Range(-5F, 5F)
			);
			counter += 1;
		}
		timer = 2F;
	}

	private void Update () {
		timer -= Time.deltaTime;
		if ( timer < 0F){
			int counter = 0;
			while (counter < 20) {
				Mover mover = this.spheres[counter].GetComponent<Mover>();
				mover.changeDirection();
				counter += 1;
			} 
			timer = 2F;
		}
	}
}
