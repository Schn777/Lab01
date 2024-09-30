using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private HandleSliders handleSliders;  // D�clare handleSliders ici

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("appleTag");
        handleSliders = GameObject.Find("Canvas").GetComponent<HandleSliders>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // V�rifiez si l'objet qui est entr� dans le trigger a le tag "Player"
        if (other.CompareTag("Player"))
        {
            handleSliders.FoodBarUp(10.2f);  // Appelle la m�thode correctement
            Destroy(gameObject);
        }
    }
}
