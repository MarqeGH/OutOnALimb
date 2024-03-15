using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_WeaponCycling : MonoBehaviour
{

    public Image UiCurrentWeapon;
    public Image UiCycleFill;

    public WeaponCycling weaponCycle;

    float isFull;
    float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = weaponCycle.timeLeft;
        isFull = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = weaponCycle.timeLeft;
        UiCycleFill.fillAmount = timeLeft/isFull;
        Debug.Log(timeLeft);
        Debug.Log(isFull);
    }
    public void ChangeWeaponImage(Sprite weapon)
    {
        UiCurrentWeapon.sprite = weapon;
    }



}
