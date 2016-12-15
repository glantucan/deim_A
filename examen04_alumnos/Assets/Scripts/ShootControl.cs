using UnityEngine;
using System.Collections;

public class ShootControl : MonoBehaviour {

	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private Transform spawnTr;

	public void Shoot () {
		GameObject bullet = Object.Instantiate(bulletPrefab);
		bullet.transform.position = spawnTr.position;
		BulletMovement bulletMovement = bullet.GetComponent<BulletMovement>();
		bulletMovement.SetDirection(this.transform.forward);
	}

}
