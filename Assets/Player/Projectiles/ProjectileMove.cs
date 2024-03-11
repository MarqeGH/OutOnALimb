using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] int speed;
    Rigidbody rb;


    void Awake() {
        rb = GetComponent<Rigidbody>();    
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(transform.forward*speed, ForceMode.Force);
    }
}
