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
        col.GetComponent<Health>()?.OnDamageTaken(damage);
        
        Destroy(gameObject);

    }

    void OnDestroy()
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
    }
}
