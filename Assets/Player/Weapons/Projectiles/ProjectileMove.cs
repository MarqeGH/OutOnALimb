using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] GameObject player;
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
        Debug.Log("please compile");
    }

    IEnumerator releaseProjectile()
    {
        yield return new WaitForSeconds(timeTillRelease);
        _pool.Release(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.transform.root.CompareTag("Player") && !other.CompareTag("Projectile"))
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
