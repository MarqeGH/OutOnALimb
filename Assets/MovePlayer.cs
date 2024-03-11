using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    public float moveSpeed = 50f;
    public float rotationSpeed;
    public Rigidbody rb;


    Vector3 movement;
    Vector3 mousePos;
    Vector3 worldPosition;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")); 
        
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.LookAt(new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z));
        }
    }
    void FixedUpdate() {
        rb.AddForce(movement.normalized * moveSpeed, ForceMode.Force);
    }
}
