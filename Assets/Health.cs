using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] float CurrentHealth;

    public GameObject DestroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamageTaken(float damage)
    {
        CurrentHealth -= damage;

        if (transform.Find("Canvas") && transform.Find("Canvas").Find("HealthBar"))
        {
            var healthbar = transform.Find("Canvas").Find("HealthBar");
            healthbar.GetComponent<Image>().fillAmount = CurrentHealth / MaxHealth;
        }

        if (CurrentHealth <= 0)
        {
            OnDeath();
        }
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }

    void OnDeath()
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(DestroyEffect, transform.position, Quaternion.identity);

        if (transform.parent)
        {
            transform.parent.GetComponent<Health>().OnDamageTaken(MaxHealth * 2);
        }
    }
}
