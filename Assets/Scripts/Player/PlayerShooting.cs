using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	public bool useBulleteTrace;
	public int damage = 40;

	public GameObject impactEffect;
	public LineRenderer lineRenderer;
	public GameObject bulletPrefab;
	public WeaponManager weaponManager;
	// Update is called once per frame
	public void ShootCall()
	{

		StartCoroutine(Shoot());

	}
	RaycastHit2D hitInfo;

	IEnumerator Shoot()
	{
		Transform firePoint = weaponManager.weaponsfirePoint[weaponManager.currentgun];


	

       
		hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
		{
			Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}

			for (int i = 0; i < weaponManager.bulletcount; i++)
			{
				Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
				Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
				yield return new WaitForSeconds(0.05f);
			}
			if (useBulleteTrace)
			{
				lineRenderer.SetPosition(0, firePoint.position);
				lineRenderer.SetPosition(1, hitInfo.point);
			}
		}
		else
		{
			if (useBulleteTrace)
			{
				lineRenderer.SetPosition(0, firePoint.position);
				lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
			}
		}

		if (useBulleteTrace)
		{
			lineRenderer.enabled = true;
			yield return 0;
			lineRenderer.enabled = false;
		}
	}



}
