using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class SizeBoostShopScript : MonoBehaviour
{
    private int totalMoney; 
    private int itemCost; 
    public Button mybutton; 
    public SkillShopController script1; 
    [SerializeField] private TextMeshProUGUI Cost;
 


    // Start is called before the first frame update
    void Start()
    {
        totalMoney = script1.money; 
        itemCost = script1.SizeBoostCost; 
        Cost.text = itemCost.ToString() + "$";
    }

    void Update(){
        totalMoney = script1.money; 
    }


    // Function to buy quicksand obstacle
    public void ButtonPressSizeBooster(){
        if (totalMoney < itemCost){
            Debug.Log("Not enough money"); 
            return; 
        }
        else {
            Debug.Log("buy Size Boost");
            totalMoney = totalMoney - itemCost; 
            script1.money = totalMoney; 
            script1.SizeBoostPurchased = true; 
            mybutton.interactable = false; 
        }

    }   
}
