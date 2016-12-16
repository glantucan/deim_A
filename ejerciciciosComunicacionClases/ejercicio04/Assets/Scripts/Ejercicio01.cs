using UnityEngine;
using System.Collections;

public class Ejercicio01 : MonoBehaviour {

	[SerializeField] GameObject cubePrefab; 
	private GameObject[] cubes;
	private KeyCode[] validKeyCodes;
	private string[] validkeys;
	
	// Use this for initialization
	void Start () {
		/*validKeyCodes = new KeyCode[10] {
			KeyCode.Alpha0,
			KeyCode.Alpha1,
			KeyCode.Alpha2,
			KeyCode.Alpha3,
			KeyCode.Alpha4,
			KeyCode.Alpha5,
			KeyCode.Alpha6,
			KeyCode.Alpha7,
			KeyCode.Alpha8,
			KeyCode.Alpha9
		};*/
		validkeys = new string[10] { "0","1","2","3","4","5","6","7","8","9"};

		cubes = new GameObject[10];

		int cubeCounter = 0;

		while (cubeCounter < 10) {
			GameObject cubeInstance = Object.Instantiate(cubePrefab);
			cubeInstance.transform.position = (cubeCounter * 3F - 15F)* Vector3.right 
					+ 0.5F * Vector3.up; 

			cubes[cubeCounter] = cubeInstance;
			cubeCounter += 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		int keyCounter = 0;

		while (keyCounter < validkeys.Length) {
			if (Input.GetKeyDown(validkeys[keyCounter])) {
				CubeJump jumper  =  cubes[keyCounter].GetComponent<CubeJump>();
				jumper.Jump();
			}
			keyCounter += 1;
		}


		
	}
}
