using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _damage;
    protected bool _held = false;

    public abstract void Shoot();
    
    
    public virtual void StopShoot()
    {
        _held = false;
    }


    public void PickupWeapon()
    {
        var player = GameObject.FindWithTag("Player");
        
        foreach (Transform child in player.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }


        //  SET PLAYER AS THE WEAPON'S PARENT
        transform.SetParent(player.GetComponent<Transform>());
        transform.localPosition = new Vector3(0,0.44f,0);
        transform.localRotation = Quaternion.Euler(0, 0, 0);

        //  SET GUN FIELD IN GUN CONTROLLER AS THIS WEAPON
        player.GetComponent<GunController>().gun = gameObject.GetComponent<Weapon>();

        
        //  DISABLE SPRITE, COLLIDER, AND CANVAS
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            PickupWeapon();
        }
   }
}
