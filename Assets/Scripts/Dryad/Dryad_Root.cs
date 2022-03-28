using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryad_Root : MonoBehaviour
{
	public GameObject root; // root prefab
	public Transform rootPointLeft; // min positiom
	public Transform rootPointRight; // max position
	private int dmg;
	public int curRoot, rootCount;
	private float x, y, z;
	private float xl, xr;

	private void Start()
	{
		dmg = GetComponent<Stats>().dmg;
		xl = rootPointLeft.transform.position.x;
		xr = rootPointRight.transform.position.x;
		y = rootPointLeft.transform.position.y;
		z = rootPointLeft.transform.position.z;
	}

	public IEnumerator GrowRoots()
    {
		curRoot = 0;
		while (curRoot < rootCount)
        {
			x = Random.Range(xl, xr);
			Instantiate(root, new Vector3(x, y, z), Quaternion.identity);
			yield return new WaitForSeconds(0.005f);
			curRoot++;
        }
    }
}
