using Gamekit2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomScript : MonoBehaviour
{
    //References
    private PlayerCharacter playerCharacterScript;
    public Animator myAnimator;

    //Movement
    public float jumpForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The player hit the mushroom
        if (collision.gameObject == playerCharacterScript.gameObject)
        {
            //Calculate the vecor of movement
            Vector3 playerMovement = transform.up * jumpForce;

            //Tell to PlayerCharacterScript how to move horizontally and vertically
            playerCharacterScript.SetHorizontalMovement(playerMovement.x);
            playerCharacterScript.SetVerticalMovement(playerMovement.y);

            //Play the animation and the sound
            myAnimator.SetTrigger("Jump");
            GetComponent<RandomAudioPlayer>().PlayRandomSound();
        }
    }
}