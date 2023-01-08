using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class SkillShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CurrentMoneyValue;
    public GameObject JumpBoostPanel; 
    public GameObject SizeBoostPanel; 
    public GameObject SpeedBoostPanel; 
    // public GameObject Skill4Panel; 
    // public GameObject Skill5Panel; 
    // public GameObject Skill6Panel; 

    public int money; 

    public int JumpBoostCost; 
    public int SizeBoostCost; 
    public int SpeedBoostCost; 
    // public int Skill4Cost; 
    // public int Skill5Cost; 
    // public int Skill6Cost; 

    public bool JumpBoostPurchased;
    public bool SizeBoostPurchased;
    public bool SpeedBoostPurchased;
    // public bool Skill4Purchased;
    // public bool Skill5Purchased;
    // public bool Skill6Purchased;


    // Start is called before the first frame update
    void Start()
    {

        // Here we gotta somehow get the money obtained by the user and store it here
        CurrentMoneyValue.text = money.ToString() + "$"; 

        if (money < JumpBoostCost){
            JumpBoostPanel.SetActive(true); 
        }

        if (money < SizeBoostCost){
            SizeBoostPanel.SetActive(true); 
        }

        if (money < SpeedBoostCost){
            SpeedBoostPanel.SetActive(true); 
        }

        // if (money < Skill4Cost){
        //     Skill4Panel.SetActive(true); 
        // }

        // if (money < Skill5Cost){
        //     Skill5Panel.SetActive(true); 
        // }

        // if (money < Skill6Cost){
        //     Skill6Panel.SetActive(true); 
        // }


    }

    // Update is called once per frame
    void Update()
    {
        CurrentMoneyValue.text = money.ToString() + "$"; 

        if (money < JumpBoostCost && JumpBoostPanel.active == false && JumpBoostPurchased == false){
            JumpBoostPanel.SetActive(true); 
        }

        if (money < SizeBoostCost && SizeBoostPanel.active == false && SizeBoostPurchased == false){
            SizeBoostPanel.SetActive(true); 
        }

        if (money < SpeedBoostCost && (SpeedBoostPanel.active == false) && (SpeedBoostPurchased == false)){
            SpeedBoostPanel.SetActive(true); 
        }
        
        // if (money < Skill4Cost && Skill4Panel.active == false && Skill4Purchased == false){
        //     Skill4Panel.SetActive(true); 
        // }

        // if (money < Skill5Cost && Skill5Panel.active == false && Skill5Purchased == false){
        //     Skill5Panel.SetActive(true); 
        // }

        // if (money < Skill6Cost && Skill6Panel.active == false && Skill6Purchased == false){
        //     Skill6Panel.SetActive(true); 
        // }

    }
}
