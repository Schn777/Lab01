using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       SceneManager.LoadScene("Niveau2");

    }

}
