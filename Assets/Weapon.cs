using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float _damage;
    protected bool _held = false;
    protected Transform firepoint;
    public bool _isActive = false;

    public abstract void Shoot();

    void Awake()
    {
        firepoint = gameObject.transform.Find("Firepoint");
    }
    
    void Start()
    {
        firepoint = gameObject.transform.Find("Firepoint");
    }

    public virtual void StopShoot()
    {
        _held = false;
    }


    public void PickupWeapon()
    {
        firepoint = gameObject.transform.Find("Firepoint");
        var player = GameObject.FindWithTag("Player");
        var gunc = player.GetComponent<GunController>();
        var weapon = GetComponent<Weapon>();

        //  SET PLAYER AS THE WEAPON'S PARENT
        transform.SetParent(player.GetComponent<Transform>());
        transform.localPosition = new Vector3(0,0,0);
        transform.localRotation = Quaternion.identity;

        //  SET GUN FIELD IN GUN CONTROLLER AS THIS WEAPON AND ADD IT TO THE INVENTORY
        gunc.inventory.Add(weapon);
        gunc.CurrentWeapon = gunc.inventory.Count - 1;
        gunc.CurrentWeaponChanged();

        
        //  DISABLE SPRITE, COLLIDER, AND CANVAS
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            PickupWeapon();
        }
   }
}
