using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthFill;
    private float maxHealth = 100f;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        UpdateHeal();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentHealth -= 10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;

            UpdateHeal();
        }
    }
    public void TakeDamage(float damageAmout)
    {
        currentHealth -= damageAmout;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeal();
    }
    public void HealBar(float healAmout)
    {
        currentHealth += healAmout;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeal();
    }
    void UpdateHeal()
    {
        float healthPercent = currentHealth / maxHealth;
        healthFill.fillAmount = healthPercent;
    }
}
