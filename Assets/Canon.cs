using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Weapon
{
    public GameObject prefab;
    private bool canshoot = true;
    [SerializeField] float firedelay = 0.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_held && canshoot)
        {
            GameObject projectile = Instantiate(prefab, firepoint.position, firepoint.rotation);
            projectile.GetComponent<CanonProjectile>().damage = _damage;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * 5f, ForceMode2D.Impulse);

            canshoot = false;
            StartCoroutine(ShootDelay());
        }

        if (DetectionArea)
        {
            CheckNearby();
        }
        
    }

    public override void Shoot()
    {
        _held = true;
    }


    IEnumerator ShootDelay()
   {
     yield return new WaitForSeconds(firedelay);
     canshoot = true;
   }
}
