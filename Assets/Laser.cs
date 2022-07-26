using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon
{
    private LineRenderer laser;
    private Vector3 target;

    // Start is called before the first frame update
    void Awake()
    {
        laser = GetComponent<LineRenderer>();
        laser.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (_held)
        {
            collisionCast();
            laser.SetPosition(0, transform.position);
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
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.5f * 0.14f, transform.up, 3f);

        if (hit)
        {
            target = hit.point;
        }
        else
        {
            target = transform.position + (transform.up * 3f);
        }
    }
}
