using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    //References
    private PlayerCharacter playerCharacterScript;

    //Prefab references
    public GameObject diamondCollectedParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The player hit the diamond
        if (collision.gameObject == playerCharacterScript.gameObject)
        {
            //Instantiate particles, play sound and destroy the diamond
            Instantiate(diamondCollectedParticleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}