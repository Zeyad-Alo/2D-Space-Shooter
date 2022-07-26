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
}
