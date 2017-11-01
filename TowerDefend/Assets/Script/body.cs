using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class body : MonoBehaviour {

	public GameObject turret;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			turret.GetComponent<Turret>().TakeDamage (col.gameObject.GetComponent<Enemy>().damage);
		}
	}
}
