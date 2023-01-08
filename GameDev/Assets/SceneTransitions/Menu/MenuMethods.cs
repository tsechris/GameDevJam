using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMethods : MonoBehaviour
{
    [SerializeField] GameObject menuButtons;
    [SerializeField] int gameSceneIndex;
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
        //SceneManager.Load(gameSceneIndex);
    }
}
