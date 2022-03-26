using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryad_SoundShoot : MonoBehaviour
{

	public float speed = 10; // fireball speed
	public Rigidbody2D fireball; // fireball prefab
	public Transform firePointLeft; // point where fireball starts moving
	public Transform firePointRight; // point where fireball starts moving
	public float destroyTime = 2f;
	public int dmg;

	//public bool endedAttacking = false;
	//public float attackTime = 2f;


	/*private IEnumerator RealoadTimer()
	{
		yield return new WaitForSeconds(attackTime);
		endedAttacking = true;
	}*/
	public void Fire()
	{
		Rigidbody2D cloneLeft = Instantiate(fireball, firePointLeft.transform.position, Quaternion.identity) as Rigidbody2D;
		cloneLeft.GetComponent<SpriteRenderer>().flipX = true;
		cloneLeft.velocity = -firePointLeft.transform.right * speed;
		cloneLeft.transform.right = firePointLeft.transform.right;
		cloneLeft.GetComponent<Fireball>().destroyTime = destroyTime;
		cloneLeft.GetComponent<Fireball>().dmg = dmg;

		Rigidbody2D cloneRight = Instantiate(fireball, firePointRight.transform.position, Quaternion.identity) as Rigidbody2D;
		cloneRight.velocity = firePointRight.transform.right * speed;
		cloneRight.transform.right = firePointRight.transform.right;
		cloneRight.GetComponent<Fireball>().destroyTime = destroyTime;
		cloneRight.GetComponent<Fireball>().dmg = dmg;
		//StartCoroutine(RealoadTimer());
	}
}