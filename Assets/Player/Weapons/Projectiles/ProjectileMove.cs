using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeTillRelease = 5;
    public Rigidbody rb;
    private ObjectPool<ProjectileMove> _pool;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        StartCoroutine(releaseProjectile());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward*speed;
    }

    IEnumerator releaseProjectile()
    {
        yield return new WaitForSeconds(timeTillRelease);
        _pool.Release(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("Player") 
            && !other.CompareTag("Projectile") 
            && !gameObject.CompareTag("Perry") 
            && !other.CompareTag("Fence"))
        {
                _pool.Release(this);
            // NOTE: Physics weird?? Sleep / Wake b4 release? Switch AddForce --> Translate + Interpolate(if rb not working)
        }
    }

    public void SetPool(ObjectPool<ProjectileMove> pool)
    {
        _pool = pool;
    }
}
