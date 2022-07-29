using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainController : MonoBehaviour
{
    [SerializeField] Vector3 moveVal;
    [SerializeField] public float moveSpeed;
    public float health = 1000;
    float currenthealth;

    private Vector3 mousePos;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    void FixedUpdate()
    {
        transform.position += moveSpeed * Time.deltaTime * moveVal;     // MOVES PLAYER EVERY FRAME

        Vector2 direction = mousePos - gameObject.transform.position;       // ROTATE PLAYER TOWARDS CURSOR
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        gameObject.GetComponent<Rigidbody2D>().rotation = angle;
    }


    public void OnMove(InputValue value)       // UNITY EVENT INVOKED BY WHENEVER MOVEMENT BUTTONS ARE PRESSED
    {
        moveVal = value.Get<Vector2>().normalized;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

}
