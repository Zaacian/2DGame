using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI textHp;
    public TextMeshProUGUI textCoin;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        updateHP();
        updateCoin();
        pauseGame();
    }
    public void updateHP()
    {
        textHp.text = "" + player.instance.hp;
    }
    public void updateCoin()
    {
        textCoin.text = "" + Gameplay.instance.coin;
    }
    public void showMenu()
    {
        //AudioManager.instance.playGUI();
        panel.SetActive(true);
        Time.timeScale = 0;
    }
    public void hideMenu()
    {
        //AudioManager.instance.playGUI();
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showMenu();
        }
    }
}
