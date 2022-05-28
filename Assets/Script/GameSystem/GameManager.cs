using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject panelGameOver;
    private GameObject exitObject;      // 출구오브젝트
    private float timeLimit = 10f;     // 제한 시간
    private bool isWave = false;       // 웨이브 스타트가 되었는지 확인변수

    public float TimeLimit => timeLimit;
   
    void Start()
    {
        Setup();
    }

    
    private void Update()
    {
        //GameOver();

        if(isWave)
        {
            timeLimit -= Time.deltaTime;
        }

        WaveClear();
    }

    private void Setup()
    {
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
        panelGameOver = GameObject.Find("PanelGameOver");
        exitObject = GameObject.Find("ExitObject");
        //panelGameOver.SetActive(false);
        exitObject.SetActive(false);
    }

    private void GameOver()
    {
        if (playerHP.CurrentHp < 0)
        {
            panelGameOver.SetActive(true);
        }
    }

    private void WaveClear()
    {
        if(timeLimit < 0)
        {
            isWave = false;
            exitObject.SetActive(true);
        }
    }

    public void WaveStart()
    {
        isWave = true;
    }


}
