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
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeTimer());
        currentHealth = maxHealth;
        currentEnergy = maxHealth;
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
            
            print(Timer);

            if (energySlider.value == 0)
            {
                Timer = 0;
            }

            yield return new WaitForSeconds(1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Attacked) {
            damageHealth(20);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentEnergy -= 10;
            currentEnergy = Mathf.Clamp(currentEnergy, 0, maxHealth);
            energySlider.value = currentEnergy;

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
