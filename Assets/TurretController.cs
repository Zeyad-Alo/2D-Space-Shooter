using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TurretController : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;
    public GameObject DestroyEffect;

    [Header("Events")]
	[Space]

	public UnityEvent Shoot;

    [System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    // Start is called before the first frame update
    void Start()
    {
        Shoot.Invoke();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,0.7f));
    }
}
