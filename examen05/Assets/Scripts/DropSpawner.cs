using UnityEngine;
using System.Collections;

public class DropSpawner : MonoBehaviour {
	[SerializeField] private GameObject dropPrefab;
	
	// Update is called once per frame
	void Update () {
		if (Time.frameCount % 2 == 0 ) {
			GameObject drop = Object.Instantiate(dropPrefab);
			drop.transform.position = new Vector3 (
				Random.Range(-1F, 1F), 
				this.transform.position.y,
				Random.Range(-1F, 1F)
			);
		}
	}
}
