using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dryad_Root : MonoBehaviour
{
	public GameObject root; // root prefab
	public Transform rootPointLeft; // min positiom
	public Transform rootPointRight; // max position
	private int dmg;
	public int rootCount;
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

	public void GrowRoots()
    {
		//curRoot = 0;
		for (int i = 0; i < rootCount; i++)
        {
			x = Random.Range(xl, xr);
			GameObject clone = Instantiate(root, new Vector3(x, y, z), Quaternion.identity) as GameObject;
			clone.GetComponent<Animator>().SetInteger("Root_Variant", Random.Range(0, 3));
			//yield return new WaitForSeconds(0.005f);
			//curRoot++;
        }
    }
}
