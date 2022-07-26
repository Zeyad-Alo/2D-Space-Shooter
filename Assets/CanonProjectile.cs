using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProjectile : Canon
{
    public GameObject HitEffect;
    public GameObject MuzzleEffect;
    public float lifetime = 2f;

    void Start()
    {
        GameObject muzzle = Instantiate(MuzzleEffect, transform.position  - new Vector3(0,0,5), Quaternion.identity);
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            Debug.Log(_damage);

            //col.gameObject.TakeDamage(_damage);       // CALLS TAKEDAMAGE FUNCTION FROM ENEMY SCRIPT

            //enemyComponent.TakeDamage(1);
        }
        
        Destroy(gameObject);

    }

    void OnDestroy()
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
    }
}
