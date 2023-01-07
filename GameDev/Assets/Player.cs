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
            if (data.direction != Vector3.up)
            {
                data.direction.Normalize();
                _cc.Move(multiplier * data.direction * Runner.DeltaTime);
            }
            else
            {
                _cc.Jump(false,0.8f);
            }
    }
}
