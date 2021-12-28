using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public bool enableDoor;

	public GameObject Door;

	public Transform Doorlocation;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
		}

		if (health <= 0)
		{
			enableDoor = true;
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		if(enableDoor)
        {
			Instantiate(Door, Doorlocation.position, Quaternion.identity);
        }
	}

}
