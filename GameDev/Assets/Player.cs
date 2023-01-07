using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    public int multiplier = 5;
    private NetworkCharacterControllerPrototype _cc;
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
}
