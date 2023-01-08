using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopTransitions : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obstacleShop;
    [SerializeField] GameObject skillsShop;
    [SerializeField] GameObject changeToSkillsButton;
    [SerializeField] GameObject changeToObstaclesButton;
    [SerializeField] int gameSceneIndex;
    private Animator anim;
    private bool inObstaclesShop = false;
    void Start() {
        anim = GetComponent<Animator>();
        DisableAllShops();
    }
    public void InitiateChangeShop()
    {
        DisableAllShops();
        anim.Play("SwitchingShop");
    }

    private void DisableAllShops()
    {
        changeToObstaclesButton.SetActive(false);
        changeToSkillsButton.SetActive(false);
        obstacleShop.SetActive(false);
        skillsShop.SetActive(false);
    }
    public void ChangeShop()
    {
        if (inObstaclesShop)
        {
            EnableSkillsShop();
            inObstaclesShop = false;
        } else {
            EnableObstaclesShop();
            inObstaclesShop = true;
        }
    }
    void EnableObstaclesShop()
    {
        obstacleShop.SetActive(true);
        changeToSkillsButton.SetActive(true);
    }
    void EnableSkillsShop()
    {
        skillsShop.SetActive(true);
        changeToObstaclesButton.SetActive(true);
    }
    public void InitiateExitShop()
    {
        DisableAllShops();
        anim.Play("ExitShop");
    }

    public void ExitShop()
    {
        // SceneManager.LoadScene(gameSceneIndex);
    }
}
