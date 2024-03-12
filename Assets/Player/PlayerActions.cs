using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerActions : MonoBehaviour
{
    
    private PlayerControls playerControls;
    private InputAction shootRight;
    private InputAction shootLeft;

    public GameObject[] weaponLeft;
    public GameObject[] weaponRight;
    // Start is called before the first frame update
    
    void Awake()
    {
        playerControls = new PlayerControls();
    }
    
    void OnEnable()
    {
        shootRight = playerControls.Controls.ShootRight;
        shootLeft = playerControls.Controls.ShootLeft;
        shootRight.performed += ShootRightWeapon;
        shootLeft.performed += ShootLeftWeapon;
        shootRight.Enable();
        shootLeft.Enable();
    }

    void OnDisable()
    {
        shootRight.Disable();
        shootLeft.Disable();
        playerControls.Controls.ShootRight.Disable();
        playerControls.Controls.ShootLeft.Disable();
    }


    // Update is called once per frame
    void Update()
    {
    }

    void ShootRightWeapon(InputAction.CallbackContext obj)
    {
       foreach (GameObject weapon in weaponRight)
       {
            if (weapon.activeSelf)
            {
                var fireWeapon = weapon.GetComponent<FireWeapon>();
                fireWeapon.Shoot();
            }
       }
    }
    void ShootLeftWeapon(InputAction.CallbackContext obj)
    {
        foreach (GameObject weapon in weaponLeft)
       {
            if (weapon.activeSelf)
            {
                var fireWeapon = weapon.GetComponent<FireWeapon>();
                fireWeapon.Shoot();
            }
       }
    }
}
