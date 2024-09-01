using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	public int health = 100;
	 
	public GameObject deathEffect;
	public void Start()
	{
		Transform player = FindAnyObjectByType<PlayerMovement>().transform;
		if(transform.position.x < player.position.x)
		{
            transform.Rotate(0f, 180f, 0f);

        }
    }
	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
        FindAnyObjectByType<EnemyManager>().InstantitaeEnemy();
        Destroy(gameObject);
	}

}
