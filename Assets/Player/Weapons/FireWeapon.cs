using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{

    public GameObject projectile;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {

    }


    public void Shoot()
    {
        Debug.Log("Shooting from " + projectile);
        Instantiate(projectile, transform.position, transform.root.transform.rotation);
    }
}
