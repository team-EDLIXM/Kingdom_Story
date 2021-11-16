using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{

	public float speed = 10; // �������� ����
	public Rigidbody2D fireball; // ������ ���������
	public Transform firePoint; // ����� ��������� ���������
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
		StartCoroutine(RealoadTimer());
	}
}