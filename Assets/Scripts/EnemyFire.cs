using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

	public float speed = 10; // скорость пули
	public GameObject fireball; // префаб нашей пули

	private bool nowhereToRun;
	private bool reloading = false;
	public float reloadTime = 1f;



	private void Update()
	{
		if (reloading) return;
		nowhereToRun = FindObjectOfType<RunningAwayEnemy>().nowhereToRun;
		if (nowhereToRun)
		{
			Fire();
		}
	}


	private IEnumerator RealoadTimer()
	{
		reloading = true;
		yield return new WaitForSeconds(reloadTime);
		reloading = false;
	}
	private void Fire()
	{

		GameObject clone = Instantiate(fireball, transform.position, Quaternion.identity) as GameObject;

		StartCoroutine(RealoadTimer());
	}
}