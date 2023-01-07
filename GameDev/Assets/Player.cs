using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class Player : NetworkBehaviour
{
    private NetworkCharacterControllerPrototype _cc;
    private void Awake() {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }
    public override void FixedUpdateNetwork()
    {
        if(GetInput(out NetworkInputData data))
        {
            data.direction.Normalize();
            _cc.Move(5* data.direction * Runner.DeltaTime);
        }
    }
}
