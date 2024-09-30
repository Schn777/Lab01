using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private HandleSliders handleSliders;  // Déclare handleSliders ici

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("appleTag");
        handleSliders = GameObject.Find("Canvas").GetComponent<HandleSliders>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet qui est entré dans le trigger a le tag "Player"
        if (other.CompareTag("Player"))
        {
            handleSliders.FoodBarUp(10.2f);  // Appelle la méthode correctement
            Destroy(gameObject);
        }
    }
}
