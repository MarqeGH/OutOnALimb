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

    public FireWeapon[] weaponLeft;
    public FireWeapon[] weaponRight;
    bool LMBisPressed;
    bool RMBisPressed;
    bool isShootingLeft = false;
    bool isShootingRight = false;


    // Start is called before the first frame update
    
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Start()
    {
        DefineShootState();
    }

    

    void OnEnable()
    {
        shootRight = playerControls.Controls.ShootRight;
        shootLeft = playerControls.Controls.ShootLeft;
        // shootRight.performed += ShootRightWeapon;
        // shootLeft.performed += ShootLeftWeapon;
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
        if (RMBisPressed)
        {
            ShootRightWeapon();
            isShootingRight = true;
        }
        else 
        {
            isShootingRight = false;
        }
        if (LMBisPressed)
        {
            ShootLeftWeapon();
            isShootingLeft = true;
        }
        else 
        {
            isShootingLeft = false;
        }
    }

    private void DefineShootState()
    {
        playerControls.Controls.ShootLeft.performed += _ => LMBisPressed = true;
        playerControls.Controls.ShootLeft.canceled += _ => LMBisPressed = false;
        playerControls.Controls.ShootRight.performed += _ => RMBisPressed = true;
        playerControls.Controls.ShootRight.canceled += _ => RMBisPressed = false;
    }

    void ShootRightWeapon()
    {
        if (!isShootingLeft)
        {
            for (int i = 0; i < weaponRight.Length; ++i)
            {
                FireWeapon weapon = weaponRight[i];
                if (weapon.gameObject.activeSelf)
                {
                    weapon.Shoot();
                    break;
                }
            }
        }
    }
    void ShootLeftWeapon()
    {
        if (!isShootingRight)
        {
            for (int i = 0; i < weaponLeft.Length; ++i)
            {
                FireWeapon weapon = weaponLeft[i];
                if (weapon.gameObject.activeSelf)
                {
                    weapon.Shoot();
                    break;
                }
            }
        }
    }
}
