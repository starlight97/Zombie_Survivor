using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    private void Update()
    {
        GameOver();
    }

    private void Setup()
    {
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
        panelGameOver = GameObject.Find("PanelGameOver").gameObject;

        panelGameOver.SetActive(false);
    }

    private void GameOver()
    {
        if (playerHP.CurrentHp < 0)
        {
            panelGameOver.SetActive(true);
        }
    }
}
