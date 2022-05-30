using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public static StageSystem instance;
    [SerializeField] private Stage[] stages;

    private Stage currentStage;                          // 현재 웨이브 정보
    private int currentStageIndex = 1;                // 스테이지 1부터 시작 ex(stage1, stage2 ...)

    // 웨이브 정보 출력을 위한 Get 프로퍼티 (현재 웨이브, 총 웨이브)
    public int CurrentStageIndex
    {
        get => currentStageIndex;
        set => currentStageIndex = value;
    }
    public int MaxStage => stages.Length;   
    public float CurrentLimitTime => stages[currentStageIndex-1].limitTime;     // 스테이지 인덱스가 1부터 시작하니까 1빼줌

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}

[System.Serializable]
public struct Stage
{
    //public float spawnTime; // 현재 웨이브 적 생성 주기
    //public int maxEnemyCount;   // 현재 웨이브 적 등장 숫자
    //public GameObject[] enemyPrefabs; // 현재 웨이브 적 등장 종류
    public float limitTime;   // 현재 웨이브 제한시간
}