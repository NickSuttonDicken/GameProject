using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    private int maxHealth = 100;
    private int minHealth = 0;
    private int regenValue = 20;
    private int currentHealth;
    private float timer = 0;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        GetSlider();
        SetMaxHealthBar();
        Debug.Log("bar");
    }

    void GetSlider()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth != maxHealth)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                RegenHealth();
                timer = 0;
            }
        }
    }

    public void SetMaxHealthBar()
    {
        if (!slider)
        {
            GetSlider();
        }
        slider.maxValue = maxHealth;
        slider.minValue = minHealth;
        slider.value = currentHealth;
    }

    private void RegenHealth()
    {
        currentHealth = currentHealth + regenValue;
        UpdateHealthBar();
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        slider.value = currentHealth;
    }

    public bool HealthDepleted()
    {
        if (currentHealth == 0 || slider.value == 0)
        {
            return true;
        }
        else return false;
    }
}