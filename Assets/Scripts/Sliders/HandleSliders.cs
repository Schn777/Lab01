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
    private ClaireController claireController;
    public Animator zombieAttack;
    private float attackWait = 1.0f;
    private float lastAttackTime = 0f;
    private GameObject zombie;

    void Start()
    {
        StartCoroutine(ChangeTimer());
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;  
        currentFood = maxFood;
        claireController = GameObject.Find("ClairePlayer").GetComponent<ClaireController>();
        zombie = GameObject.Find("Mremireh O Desbiens");
        zombieAttack = zombie.GetComponent<Animator>();
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
            //energySlider.value-=10;
            //foodSlider.value-=10;

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
        if(zombie != null)
        {
            Attacked = zombieAttack.GetCurrentAnimatorStateInfo(0).IsTag("ZombeAttacking");
            if (Attacked && Time.time >= lastAttackTime + attackWait)
            {
                Debug.Log("Attack");
                zombieAttack.ResetTrigger("isShooting");
                damageHealth(10);
                lastAttackTime = Time.time;
            }
        }
        

        //if (Attacked)
        //{
        //    damageHealth(40);
        //}
        if (foodSlider.value <= 0 || healthSlider.value <= 0 || energySlider.value <= 0)
        {
            claireController.isDead = true;
        }
        
    }
    

    public void HealBar(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHeal();
    }

    public void FoodBarUp(float foodAmount) 
    {
       
        currentFood += foodAmount;
        currentFood = Mathf.Clamp(currentFood, 0, maxFood);
        foodSlider.value = currentFood;  
    }
    public void EnergyBarUp(float energyAmount)  
    {
        currentEnergy += energyAmount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        energySlider.value = currentEnergy; 
    }
    void UpdateHeal()
    {
        float healthPercent = currentHealth / maxHealth;
        healthFill.fillAmount = healthPercent;
    }
}
