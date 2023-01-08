using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Unity.VisualScripting;

public class Player : NetworkBehaviour
{
    public int multiplier = 5;
    private NetworkCharacterControllerPrototype _cc;
    public bool hasWon;
    private Animator playerAnim;
    public AudioClip runClip;
    public AudioClip jumpClip;
    private AudioSource playerAudio;


    private void Awake() {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
        playerAudio = GetComponent<AudioSource>();
    }
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))

        {
            if (data.jump)
            {
                _cc.Jump(false);
                playerAnim.SetBool("isJumping", true);
                playerAudio.PlayOneShot(runClip);
            }
            data.direction.Normalize();
            _cc.Move(multiplier * data.direction * Runner.DeltaTime);
            playerAnim.SetBool("isRunning", true);
            playerAnim.SetBool("isJumping", false);
            playerAudio.PlayOneShot(jumpClip, 1.0f);
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            hasWon = true;
            //playerAnim.SetBool("hasWon", true) ;
        }
    }
}
