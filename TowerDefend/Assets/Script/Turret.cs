﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{

	public List<GameObject> enemys = new List<GameObject>();
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Enemy")
		{
			enemys.Add(col.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Enemy")
		{
			enemys.Remove(col.gameObject);
		}
	}

	public float hp = 500;
	private float totalHp;
	public Slider hpSlider;
	public GameObject explosionEffect;

	public float attackRateTime = 1; //多少秒攻击一次
	private float timer = 0;

	public GameObject bulletPrefab;//子弹
	public Transform firePosition;
	public Transform head;

	public bool useLaser = false;

	public float damageRate = 70;

	public LineRenderer laserRenderer;

	public GameObject laserEffect;


	void Start()
	{
		timer = attackRateTime;
		totalHp = hp;
		hpSlider = GetComponentInChildren<Slider>();
	}

	void Update()
	{
		//if (head.rotation.y!=-90)
		//{
		//    head.rotation = Quaternion.Euler(new Vector3(90, -180, 90));
		//}

		if (enemys.Count > 0 && enemys[0] != null)
		{
			Vector3 targetPosition = enemys[0].transform.position;


			Vector3 enemyDir = targetPosition - head.transform.position;

			head.transform.up = enemyDir.normalized * -1;
		}
		else
		{
			head.transform.up = Vector3.Lerp(head.transform.up, new Vector3(0, 1, 0), 3.5f);
		}
		if (useLaser == false)
		{
			timer += Time.deltaTime;
			if (enemys.Count > 0 && timer >= attackRateTime)
			{
				timer = 0;
				Attack();
			}
		}
		else if (enemys.Count > 0)
		{
			if (laserRenderer.enabled == false)
				laserRenderer.enabled = true;
			laserEffect.SetActive(true);
			if (enemys[0] == null)
			{
				UpdateEnemys();
			}
			if (enemys.Count > 0)
			{
				laserRenderer.SetPositions(new Vector3[] { firePosition.position, enemys[0].transform.position });
				enemys[0].GetComponent<Enemy>().TakeDamage(damageRate * Time.deltaTime);
				laserEffect.transform.position = enemys[0].transform.position;
				Vector3 pos = transform.position;
				pos.y = enemys[0].transform.position.y;
				laserEffect.transform.LookAt(pos);
			}
		}
		else
		{
			laserEffect.SetActive(false);
			laserRenderer.enabled = false;
		}
	}


	void Attack()
	{
		if (enemys[0] == null)
		{
			UpdateEnemys();
		}
		if (enemys.Count > 0)
		{
			GameObject bullet = GameObject.Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
			bullet.GetComponent<Bullet>().SetTarget(enemys[0].transform);
		}
		else
		{
			timer = attackRateTime;
		}
	}

	public void TakeDamage(float damage)
	{
		if (hp <= 0) return;
		hp -= damage;
		hpSlider.value = (float)hp / totalHp;
		if (hp <= 0)
		{
			Die();
		}
	}
	void Die()
	{
		MapManager.turretCount -= 1;
		GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
		Destroy(effect, 1.5f);
		Destroy(this.gameObject);
	}

	void UpdateEnemys()
	{
		//enemys.RemoveAll(null);
		List<int> emptyIndex = new List<int>();
		for (int index = 0; index < enemys.Count; index++)
		{
			if (enemys[index] == null)
			{
				emptyIndex.Add(index);
			}
		}

		for (int i = 0; i < emptyIndex.Count; i++)
		{
			enemys.RemoveAt(emptyIndex[i] - i);
		}
	}
}
