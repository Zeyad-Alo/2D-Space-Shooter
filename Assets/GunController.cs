using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{

    public List<Weapon> inventory = new List<Weapon>();
    public int CurrentWeapon;
    private int PreviousWeapon = -1;


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) 
        {
            if (child.gameObject.CompareTag("Weapon"))
                inventory.Add(child.gameObject.GetComponent<Weapon>());
        }
    }

    void OnScroll(InputValue value)
    {
        if (inventory.Count != 0)
        {
            CurrentWeapon = Mathf.Abs((CurrentWeapon + (int)value.Get<float>()/120) % inventory.Count);
            CurrentWeaponChanged();
        }
    }

    public void OnFire()       // UNITY EVENT INVOKED WHENEVER FIRE BUTTON IS PRESSED
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if(inventory.Count != 0 && inventory[i]._isActive)
            {
                inventory[i].Shoot();
            }
        }
    }

    void Update()
    {
        if(Mouse.current.leftButton.wasReleasedThisFrame && inventory.Count != 0 && CompareTag("Player"))
            {
                inventory[CurrentWeapon].StopShoot();
            }
    }

    public void CurrentWeaponChanged()
    {
        if (CurrentWeapon != PreviousWeapon)
        {
            if (PreviousWeapon != -1)
            {
                inventory[PreviousWeapon]._isActive = false;
                inventory[PreviousWeapon].GetComponent<SpriteRenderer>().enabled = false;
            }
            inventory[CurrentWeapon]._isActive = true;
            inventory[CurrentWeapon].GetComponent<SpriteRenderer>().enabled = true;
            PreviousWeapon = CurrentWeapon;
        }
    }

    public void SetAllActive()
    {
        int i = 0;

         foreach (Transform child in transform) 
        {
            if (!child.gameObject.CompareTag("Light"))
            {
                //inventory.Add(child.GetComponent<Weapon>());
                inventory[i]._isActive = true;
                i += 1;
            }
        }

        // for (int i = 0; i < inventory.Count; i++)
        // {
        //     inventory[i]
        //     inventory[i]._isActive = true;
        // }
    }
}
