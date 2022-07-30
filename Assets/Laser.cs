using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    private LineRenderer laser;
    public float LaserWidth;
    private Vector3 target;
    public GameObject HitEffect;
    public float Range = 4f;

    // Start is called before the first frame update
    void Awake()
    {
        laser = GetComponent<LineRenderer>();
        laser.startWidth = LaserWidth;
        laser.positionCount = 2;
        //_damage = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_held)
        {
            collisionCast();
            laser.SetPosition(0, firepoint.position);
            laser.SetPosition(1, target);
        }
    }

    public override void Shoot()
    {
        _held = true;
    }

    public override void StopShoot()
    {
        _held = false;
        var pos = new Vector3(0,0,0);
        laser.SetPosition(0, pos);
        laser.SetPosition(1, pos);
    }

    void collisionCast()
    {
        RaycastHit2D hit = Physics2D.CircleCast(firepoint.position, 0.5f * 0.14f, transform.up, Range);

        if (hit)
        {
            target = hit.point;
            GameObject effect = Instantiate(HitEffect, hit.point, Quaternion.identity);
            hit.transform.gameObject.GetComponent<Health>()?.OnDamageTaken(_damage);
        }
        else
        {
            target = firepoint.position + (transform.up * Range);
        }
    }
}
