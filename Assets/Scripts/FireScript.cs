using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{

	public float speed = 10; // fireball speed
	public Rigidbody2D fireball; // fireball prefab
	public Transform firePoint; // point where fireball starts moving
	public float destroyTime = 2f;

	public bool reloading = false;
	public float reloadTime = 1f;


	private IEnumerator RealoadTimer()
	{
		reloading = true;
		yield return new WaitForSeconds(reloadTime);
		reloading = false;
	}
	public void Fire()
	{

		Rigidbody2D clone = Instantiate(fireball, firePoint.transform.position, Quaternion.identity) as Rigidbody2D;
		clone.velocity = firePoint.transform.right * speed;
		clone.transform.right = firePoint.transform.right;
		clone.GetComponent<Fireball>().destroyTime = destroyTime;
		clone.GetComponent<Fireball>().dmg = GetComponent<Stats>().dmg;
		StartCoroutine(RealoadTimer());
	}
}