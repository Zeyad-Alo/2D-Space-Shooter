using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GunController : MonoBehaviour
{

    public Weapon gun;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)       // UNITY EVENT INVOKED WHENEVER FIRE BUTTON IS PRESSED
    {
        if(context.performed)
        {
            gun.Shoot();
        }
        if(context.canceled)
        {
            gun.StopShoot();
        }
    }
}
