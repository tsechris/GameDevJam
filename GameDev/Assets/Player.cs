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
    private void Awake() {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }
    public override void FixedUpdateNetwork()
    {
        if(GetInput(out NetworkInputData data))
        
        {
            if (data.jump)
            {
                _cc.Jump(false);
            }
            data.direction.Normalize();
            _cc.Move(multiplier * data.direction * Runner.DeltaTime);
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor"))
        {
            hasWon = true;
        }
    }
}
