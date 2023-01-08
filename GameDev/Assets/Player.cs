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
        playerAnim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }
    public override void FixedUpdateNetwork()
    {
        bool jumpRequested = false;
        bool inputIdle = false;

        if (GetInput(out NetworkInputData data))
        {
            if (data.jump)
            {
                _cc.Jump(false);
                jumpRequested = true;
                playerAudio.PlayOneShot(runClip);
            }
            data.direction.Normalize();
            _cc.Move(multiplier * data.direction * Runner.DeltaTime);
            if (data.direction == Vector3.zero) {
                inputIdle = true;
            }
            playerAudio.PlayOneShot(jumpClip, 1.0f);
        }
        
        if ((_cc.Velocity == Vector3.zero || inputIdle) & _cc.IsGrounded)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isRunning", false);
        }
        else if ((!_cc.IsGrounded) || jumpRequested)
        {
            playerAnim.SetBool("isJumping", true);
            playerAnim.SetBool("isRunning", false);
        }
        else if (_cc.IsGrounded)
        {
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isRunning", true);
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
