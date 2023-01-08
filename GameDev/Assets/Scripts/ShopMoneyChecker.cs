using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro; 

public class ShopMoneyChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentMoneyValue;
    public GameObject quicksandPanel; 
    public GameObject tumbleweedPanel; 
    public GameObject cactusPanel; 
    public GameObject jumpquestPanel; 
    public GameObject inkscreenPanel; 
    public GameObject controlswapPanel; 
    public int money; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentMoneyValue.text = money.ToString() + "$"; 

        if (money < 20){
            quicksandPanel.SetActive(true); 
        }

        if (money < 20){
            tumbleweedPanel.SetActive(true); 
        }

        if (money < 20){
            cactusPanel.SetActive(true); 
        }

        if (money < 20){
            jumpquestPanel.SetActive(true); 
        }

        if (money < 20){
            inkscreenPanel.SetActive(true); 
        }

        if (money < 20){
            controlswapPanel.SetActive(true); 
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (money < 20 && (quicksandPanel.active == false)){
            Debug.Log("activate hidden pannel");
            quicksandPanel.SetActive(true); 
        }

        if (money < 20 && tumbleweedPanel.active == false){
            tumbleweedPanel.SetActive(true); 
        }

        if (money < 20 && cactusPanel.active == false){
            cactusPanel.SetActive(true); 
        }
        
        if (money < 20 && jumpquestPanel.active == false){
            jumpquestPanel.SetActive(true); 
        }

        if (money < 20 && inkscreenPanel.active == false){
            inkscreenPanel.SetActive(true); 
        }

        if (money < 20 && controlswapPanel.active == false){
            controlswapPanel.SetActive(true); 
        }

    }
}
