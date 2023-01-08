using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ShopController : MonoBehaviour
{
    public int money; 
    [SerializeField] private TextMeshProUGUI CurrentMoneyValue;
    public Button mybutton; 

    void Start() {
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    // Function to return to previous page
    public void ButtonPressExit(){
        Debug.Log("Returning to main menu");
    }   

    // Function to buy quicksand obstacle
    public void ButtonPressQuicksand(){
        if (money < 20){
            Debug.Log("Not enough money"); 
            return; 
        }
        else {
            Debug.Log("buy quicksand");
            money = money - 20; 
            CurrentMoneyValue.text = money.ToString() + "$";
            mybutton.interactable = false; 

        }


    }   

    // Function to buy tumbleweed obstacle
    public void ButtonPressTumbleweed(){
        Debug.Log("buy tumbleweed");
    }   

    // Function to buy cactus obstacle
    public void ButtonPressCactus(){
        Debug.Log("buy cactus");
    }   

    // Function to buy jumpquest obstacle
    public void ButtonPressJumpquest(){
        Debug.Log("buy jumpquest");
    }   

    // Function to buy inkscreen obstacle
    public void ButtonPressInkscreen(){
        Debug.Log("buy inkscreen");
    }   

    // Function to buy control swap obstacle
    public void ButtonPressControlSwap(){
        Debug.Log("buy Control Swap");
    }   
}


