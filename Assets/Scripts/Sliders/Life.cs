using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Life : MonoBehaviour
{
    public Slider healthSlider;
    public Image healthFill;
    private float maxHealth = 100f;
    private float currentHealth;
   
    public bool Attacked = false;
    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        UpdateHeal();
    }



    // Update is called once per frame
    void Update()
    {

        
        if (Attacked)
        {
            currentHealth -= 10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            healthSlider.value = currentHealth;
            Attacked = !Attacked;
           // UpdateHeal();
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