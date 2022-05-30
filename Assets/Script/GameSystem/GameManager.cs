using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private PlayerHP playerHP;
    private GameObject panelGameOver;
    private GameObject exitObject;      // 출구오브젝트
    private float timeLimit;     // 제한 시간
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
    /// 다음 스테이지 호출 함수
    /// </summary>
    public void NextStage()
    {

        if (StageSystem.instance.CurrentStageIndex < StageSystem.instance.MaxStage)
        {
            SceneManager.LoadScene("stage" + (StageSystem.instance.CurrentStageIndex));
            StageSystem.instance.CurrentStageIndex++;
        }       
        // 게임 클리어
        else
        {
            // 게임 클리어 코드
        }
    }
    /// <summary>
    /// 현제 스테이지 레벨에 따라 스테이지 셋팅 함수
    /// </summary>
    private void StageSetting()
    {
        timeLimit = StageSystem.instance.CurrentLimitTime;
    }

}
