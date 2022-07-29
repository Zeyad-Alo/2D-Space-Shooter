using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : Weapon
{
    public GameObject prefab;
    private bool canshoot = true;
    [SerializeField] float firedelay = 0.5f;

    // void Awake()
    // {
    //     _damage = 1f;
    // }

    // Start is called before the first frame update
    void Start()
    {
        //prefab = GameObject.FindWithTag("Projectile");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_held && canshoot)
        {
            GameObject projectile = Instantiate(prefab, firepoint.position, firepoint.rotation);
            projectile.GetComponent<CanonProjectile>().damage = 30;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * 5f, ForceMode2D.Impulse);

            canshoot = false;
            StartCoroutine(ShootDelay());
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
