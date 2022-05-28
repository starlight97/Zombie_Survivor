using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject panelGameOver;
    private GameObject exitObject;      // �ⱸ������Ʈ
    private float timeLimit = 10f;     // ���� �ð�
    private bool isWave = false;       // ���̺� ��ŸƮ�� �Ǿ����� Ȯ�κ���

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
