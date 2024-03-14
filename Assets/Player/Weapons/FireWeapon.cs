using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class FireWeapon : MonoBehaviour
{

    public ObjectPool<ProjectileMove> _pool;
    public ProjectileMove prefab;
    [SerializeField] int defaultPool;
    [SerializeField] int poolSize;
    [SerializeField] float attackSpeed;
    float timePassed;

    void Start()
    {
        _pool = new ObjectPool<ProjectileMove>(CreateProjectile, OnGetProjectileFromPool, OnReleaseProjectileFromPool, OnDestroyFromPool, true, defaultPool, poolSize);
    // POOL ORDER: (D)Create P on load --> (D-)Action on get P --> Action on Destroy P --/
    //--> Collection Check(did I already release P?) --> Default Capacity --> Max Capacity
    }

    void Update()
    {
        timePassed += Time.deltaTime;
    }

    public void Shoot()
    {
        if (timePassed > attackSpeed)
        {
            _pool.Get();
            timePassed = 0;
        }
    }




    private ProjectileMove CreateProjectile()
    {
        // Spawn new instance of bullet
        ProjectileMove projectile = Instantiate(prefab, transform.position, transform.root.transform.rotation);
        // Debug.Log("root: " + transform.root);
        // Debug.Log("Projectile transform: " + transform.rotation);
        // Debug.Log("Root transform: " + transform.root.transform.rotation);
        // Assign the bullet's pool
        projectile.SetPool(_pool);
        
        // return value
        return projectile;
    }

    // What to do when taking Projectile from Pool
    private void OnGetProjectileFromPool(ProjectileMove projectile)
    {
        // Reset projectile position & rotation to Weapon pos and Player Rotation
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.root.transform.rotation;
        projectile.gameObject.SetActive(true);
        
        // Debug.Log("root: " + transform.root);
        // Debug.Log("Projectile transform: " + transform.position);
        // Debug.Log("Root transform: " + transform.root.transform.rotation.eulerAngles);
    }

    private void OnReleaseProjectileFromPool(ProjectileMove projectile)
    {
        projectile.gameObject.SetActive(false);
    }

    private void OnDestroyFromPool(ProjectileMove projectile)
    {
        Destroy(projectile.gameObject);
    }
}
