using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject panelGameOver;
    private GameObject exitObject;      // �ⱸ������Ʈ
    private float timeLimit;     // ���� �ð�
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

        StageClear();
    }

    private void Setup()
    {
        playerHP = GameObject.Find("Player").GetComponent<PlayerHP>();
        panelGameOver = GameObject.Find("PanelGameOver");
        exitObject = GameObject.Find("ExitObject");
        //panelGameOver.SetActive(false);
        exitObject.SetActive(false);
        StageSetting();
    }

    private void GameOver()
    {
        if (playerHP.CurrentHp < 0)
        {
            panelGameOver.SetActive(true);
        }
    }

    private void StageClear()
    {
        if(timeLimit < 0)
        {            
            isWave = false;
            exitObject.SetActive(true);
        }
    }

    public void StageStart()
    {
        isWave = true;
    }

    /// <summary>
    /// ���� �������� ȣ�� �Լ�
    /// </summary>
    public void NextStage()
    {

        if (StageSystem.instance.CurrentStageIndex < StageSystem.instance.MaxStage)
        {
            SceneManager.LoadScene("stage" + (StageSystem.instance.CurrentStageIndex));
            StageSystem.instance.CurrentStageIndex++;
        }       
        // ���� Ŭ����
        else
        {
            // ���� Ŭ���� �ڵ�
        }
    }
    /// <summary>
    /// ���� �������� ������ ���� �������� ���� �Լ�
    /// </summary>
    private void StageSetting()
    {
        timeLimit = StageSystem.instance.CurrentLimitTime;
    }

}
