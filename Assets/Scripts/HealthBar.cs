using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthFill;
    private float maxHealth = 100f;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        UpdateHealthBar();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            //healthSlider.value = currentHealth;

            UpdateHealthBar();
        }
    }
    public void TakeDamage(float damageAmout)
    {
        currentHealth -= damageAmout;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    public void Heal(float healAmout)
    {
        currentHealth += healAmout;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        float healthPercent = currentHealth / maxHealth;
        healthFill.fillAmount = healthPercent;
    }
}