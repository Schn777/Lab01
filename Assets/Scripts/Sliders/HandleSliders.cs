using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSliders : MonoBehaviour
{
    public float Timer = 60;
    public Slider healthSlider;
    public Slider energySlider;
    public Slider foodSlider;
    public Image healthFill;
    private float maxHealth = 100f;
    private float maxEnergy = 100f;
    private float maxFood = 100f;
    private float currentHealth;
    private float currentEnergy;
    private float currentFood;
    public bool Attacked = false;

    void Start()
    {
        StartCoroutine(ChangeTimer());
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;  // Correction ici
        currentFood = maxFood;
        UpdateHeal();
    }

    void damageHealth(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthSlider.value = currentHealth;
        Attacked = !Attacked;
    }

    IEnumerator ChangeTimer()
    {
        while (Timer > 0)
        {
            energySlider.value--;
            foodSlider.value--;

            print(Timer);

            if (energySlider.value == 0)
            {
                Timer = 0;
            }

            yield return new WaitForSeconds(1);
        }
    }

    void Update()
    {
        if (Attacked)
        {
            damageHealth(20);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeal();
    }

    public void HealBar(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeal();
    }

    public void FoodBarUp(float foodAmount)  // Ne pas mettre static ici
    {
        Debug.Log("FoodBar");
        currentFood += foodAmount;
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
        foodSlider.value = currentFood;  // Met à jour le slider
    }

    void UpdateHeal()
    {
        float healthPercent = currentHealth / maxHealth;
        healthFill.fillAmount = healthPercent;
    }
}
