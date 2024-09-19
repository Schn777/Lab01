using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    //https://discussions.unity.com/t/detect-if-player-is-in-range/99984
    public GameObject player;
    Animator creatureAnimator;
    public int maxRange;
    public int minRange;
    public List<AudioClip> listAudioClip;

    public AudioSource audioSource;
    private bool isOnTimePlay;

    // Start is called before the first frame update
    void Start()
    {
        creatureAnimator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
            
        if ((Vector3.Distance(transform.position, player.transform.position) < maxRange)
           && (Vector3.Distance(transform.position, player.transform.position) > minRange))
        {
            creatureAnimator.SetBool("Attack", true);
            if (!isOnTimePlay) {
                audioSource.PlayOneShot(listAudioClip[Random.Range(0, listAudioClip.Count)]);
                isOnTimePlay = true;
            }

        } else {
            creatureAnimator.SetBool("Attack", false);
            isOnTimePlay = false;
        }
    }
}