using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProjectile : MonoBehaviour
{
    public GameObject HitEffect;
    public GameObject MuzzleEffect;
    public float lifetime = 2f;
    public float damage;

    void Start()
    {
        GameObject muzzle = Instantiate(MuzzleEffect, transform.position, transform.rotation);
        Destroy(gameObject, lifetime);

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            col.GetComponent<TurretController>()?.TakeDamage(damage);
        }
        else if (col.CompareTag("Player"))
        {
            col.GetComponent<MainController>()?.TakeDamage(damage);
        }
        
        Destroy(gameObject);

    }

    void OnDestroy()
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
    }
}
