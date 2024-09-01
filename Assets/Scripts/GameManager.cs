using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public Transform playertransform;

   [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public WeaponManager weaponManager;
    [HideInInspector] public PlayerShooting playerShooting;
     
    // Start is called before the first frame update
    void Start()
    {
        ///Select and Activate Player Here if multiple characters 

        playerMovement = playertransform.GetComponent<PlayerMovement>();
        weaponManager = playertransform.GetComponent<WeaponManager>();
        playerShooting = playertransform.GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    public void ShhotButton()
    {
        playerShooting.ShootCall();
    }
    public  void SelectPistol()
    {
        weaponManager.SwitchWeapon(0);
    }
    public void SelectShotgun()
    {
        weaponManager.SwitchWeapon(1);

    }

    public void hideGun(bool ishide)
    {
        weaponManager.weaponsParent.SetActive(!ishide);
    }
}
