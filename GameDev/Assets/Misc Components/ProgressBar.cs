using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] Scrollbar P1Progress;
    [SerializeField] Scrollbar P2Progress;
    //Assuming that both players start and end on the same z level
    private float player1StartPos = 0f;
    private float player2StartPos = 0f;
    [SerializeField] float endPos = 0f;
    void Start() 
    {
        player1StartPos = player1.GetComponent<Transform>().position.x;
        player2StartPos = player2.GetComponent<Transform>().position.x;
    }
    void Update()
    {
        if (Mathf.Abs(endPos - player1.GetComponent<Transform>().position.x) < Mathf.Abs(endPos - player1StartPos))
        {
            P1Progress.value = ((player1.GetComponent<Transform>().position.x - player1StartPos) / (endPos - player1StartPos));
        } else {
            P1Progress.value = 0;
        }
        if (Mathf.Abs(endPos - player2.GetComponent<Transform>().position.x) < Mathf.Abs(endPos - player2StartPos))
        { 
            P2Progress.value = ((player2.GetComponent<Transform>().position.x - player1StartPos) / (endPos - player2StartPos));        
        } else {
            P2Progress.value = 0;
        }
    }
}
