using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPlantShot : MonoBehaviour
{

	public float speed;
	public Rigidbody2D seed;
	public Transform firePoint;
	public float destroyTime = 2f;

	public bool reloading = false;
	public float reloadTime = 1f;


	private IEnumerator RealoadTimer()
	{
		reloading = true;
		yield return new WaitForSeconds(reloadTime);
		reloading = false;
	}
	public void Shoot()
	{
		Rigidbody2D clone = Instantiate(seed, firePoint.transform.position, Quaternion.identity) as Rigidbody2D;
		clone.velocity = firePoint.transform.right * speed;
		clone.transform.right = firePoint.transform.right;
		clone.GetComponent<Seed>().destroyTime = destroyTime;
		clone.GetComponent<Seed>().dmg = GetComponent<Stats>().dmg;
		GetComponent<SnapPlant>().currentAttack++;
		StartCoroutine(RealoadTimer());
	}
}