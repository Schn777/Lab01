using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour
{
   private HandleSliders handleSliders; 

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("appleTag");
        handleSliders = GameObject.Find("Canvas").GetComponent<HandleSliders>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            handleSliders.EnergyBarUp(10.2f);  
            Destroy(gameObject);
        }
    }
}
