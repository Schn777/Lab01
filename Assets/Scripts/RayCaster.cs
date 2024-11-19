using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayCaster : MonoBehaviour
{
    public LayerMask groundLayer;
    public float rayLength = 0.1f; 
    public ParticleSystem attackParticle;
    public GameObject zombie;

    private bool isGrounded;
    private bool isJump = false;
    private float atckCount = 0;
    float distance;
    void Start()
    {
        attackParticle = GameObject.FindWithTag("AttackParticle").GetComponent<ParticleSystem>();
        attackParticle.Stop();
    }
    void Update()
    {
        
        // Lancer un rayon vers le bas depuis la position du joueur
        isGrounded = Physics.Raycast(transform.position, Vector3.down, rayLength, groundLayer);
        if (!isGrounded)
        {
            isJump = true;
            attackParticle.Stop();
        }
        if (zombie != null)
        {
            distance = Vector3.Distance(transform.position, zombie.transform.position);

            if (isJump && isGrounded)
            {
                attackParticle.Play();
                if (distance < 4.0f)
                {
                    Debug.Log("Atck in distance ------------: " + atckCount);
                    atckCount++;
                    if (atckCount > 4)
                    {
                        Destroy(zombie);
                    }
                }
                isJump = false;
            }
        }
       
    }
}
