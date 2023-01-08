using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMethods : MonoBehaviour
{
    [SerializeField] GameObject menuButtons;
    [SerializeField] GameObject networkMenu;
    [SerializeField] GameObject parentObject;
    private Animator anim;
    void Start() {
        anim = GetComponent<Animator>();
        menuButtons.SetActive(false);    
    }

    public void EnableButtons()
    {
        menuButtons.SetActive(true);
    }

    public void StartGame()
    {
        menuButtons.SetActive(false);
        anim.Play("ExitMenu");
    }

    public void LoadGameScene()
    {
        networkMenu.SetActive(true);
        parentObject.SetActive(false);
    }
}
