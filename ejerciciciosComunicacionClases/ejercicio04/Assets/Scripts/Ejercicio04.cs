using UnityEngine;
using System.Collections;

public class Ejercicio04 : MonoBehaviour {
	[SerializeField] private GameObject cubePrefab;

	private GameObject[] cubes;

	private void Start () {
		cubes = new GameObject[10];
		int counter = 0;

		while (counter < 10) {
			cubes[counter] = Object.Instantiate(cubePrefab);
			cubes[counter].transform.position = counter * 3F * Vector3.right;  
			counter += 1;
		}

		counter = 0;

		while (counter < 9) {
			CubeMovement movement = cubes[counter].GetComponent<CubeMovement>();
			movement.SetTarget( cubes[counter + 1] );
			counter += 1;
		}

		CubeMovement firstCubeMovement = cubes[0].GetComponent<CubeMovement>();
		firstCubeMovement.StartMovement();

	}

}
