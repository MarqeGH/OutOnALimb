using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponCycling : MonoBehaviour
{


    List<GameObject> weapons = new List<GameObject>();
    int random;
    GameObject weaponHolder;
    GameObject currentWeapon;
    public UI_WeaponCycling UIWeapon;



    [SerializeField] float timeCap = 100f;
    [SerializeField] float timeReduce = 12.5f;

    float timeHalf;
    public float timeLeft;

    // Start is called before the first frame update
    void Awake()
    {
        weaponHolder = gameObject;
        DefineWeaponsAtStart();
        timeLeft = timeCap;
        timeHalf = timeCap/2;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= timeReduce*Time.deltaTime;
        timeLeft = Mathf.Clamp(timeLeft, 0f, timeCap);
        if (timeLeft <= 0)
        {
            timeLeft = timeCap;
            ChangeActiveWeapon();
        }
    }

    void ChangeActiveWeapon()
    {
        random = Random.Range(0, weapons.Count);
        currentWeapon.SetActive(false); 
        if (currentWeapon == weapons[random]){
            ChangeActiveWeapon();
        }
        else 
        { 
            currentWeapon = weapons[random];
            currentWeapon.SetActive(true);
            UIWeapon.ChangeWeaponImage(currentWeapon.GetComponent<FireWeapon>().weaponImage);
            Debug.Log("Changing "+ weaponHolder + " to " + currentWeapon + ".");
        }
    }
    void DefineWeaponsAtStart()
    {
        foreach (Transform child in weaponHolder.transform)
        {
            weapons.Add(child.gameObject);
        }
        random = Random.Range(0, weapons.Count);
        currentWeapon = weapons[random];
        currentWeapon.SetActive(true);
        Debug.Log(currentWeapon.GetComponent<FireWeapon>().weaponImage);
        UIWeapon.ChangeWeaponImage(currentWeapon.GetComponent<FireWeapon>().weaponImage);
        // UIWeapon.ChangeWeaponImage(currentWeapon.GetComponent<FireWeapon>().weaponImage);
    }
    public void FillWeaponTime(float fill)
    {
        timeLeft += fill;
    }
}
