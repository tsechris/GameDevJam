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

    public int QuicksandCost; 
    public int TumbleweedCost; 
    public int CactusCost; 
    public int JumpQuestCost; 
    public int InkescreenCost; 
    public int ConstrolSwapCost; 

    public bool quicksandPurchased;
    public bool TumbleweedPurchased;
    public bool CactusPurchased;
    public bool JumpQuestPurchased;
    public bool InkescreenPurchased;
    public bool ConstrolSwapPurchased;


    // Start is called before the first frame update
    void Start()
    {

        // Here we gotta somehow get the money obtained by the user and store it here
        CurrentMoneyValue.text = money.ToString() + "$"; 

        if (money < QuicksandCost){
            quicksandPanel.SetActive(true); 
        }

        if (money < TumbleweedCost){
            tumbleweedPanel.SetActive(true); 
        }

        if (money < CactusCost){
            cactusPanel.SetActive(true); 
        }

        if (money < JumpQuestCost){
            jumpquestPanel.SetActive(true); 
        }

        if (money < InkescreenCost){
            inkscreenPanel.SetActive(true); 
        }

        if (money < ConstrolSwapCost){
            controlswapPanel.SetActive(true); 
        }


    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoneyValue.text = money.ToString() + "$"; 

        if (money < QuicksandCost && (quicksandPanel.active == false) && (quicksandPurchased == false)){
            quicksandPanel.SetActive(true); 
        }

        if (money < TumbleweedCost && tumbleweedPanel.active == false && TumbleweedPurchased == false){
            tumbleweedPanel.SetActive(true); 
        }

        if (money < CactusCost && cactusPanel.active == false && CactusPurchased == false){
            cactusPanel.SetActive(true); 
        }
        
        if (money < JumpQuestCost && jumpquestPanel.active == false && JumpQuestPurchased == false){
            jumpquestPanel.SetActive(true); 
        }

        if (money < InkescreenCost && inkscreenPanel.active == false && InkescreenPurchased == false){
            inkscreenPanel.SetActive(true); 
        }

        if (money < ConstrolSwapCost && controlswapPanel.active == false && ConstrolSwapPurchased == false){
            controlswapPanel.SetActive(true); 
        }

    }
}
