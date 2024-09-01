using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum WeaponType { Pistol, Shotgun }

public class WeaponManager : MonoBehaviour
{
    //public WeaponType currentWeapon = WeaponType.Pistol;
    public GameManager gameManager;
    int previousgun=0;
    [HideInInspector]public int currentgun=0;
    public GameObject weaponsParent;
    public Transform[] weapons;
    public Transform[] weaponsfirePoint;
    [HideInInspector] public int bulletcount;
    public void Start()
    {
        SwitchWeapon(0);
    }
    public void SwitchWeapon(int gunindex)
    {
      //  currentWeapon = WeaponType.Pistol;
        currentgun = gunindex;
       weapons[previousgun].gameObject.SetActive(false);
        weapons[currentgun].gameObject.SetActive(true);
        previousgun = currentgun;

        bulletcount = (gunindex == 0 ) ? 1 : 5;
    }
   
}

