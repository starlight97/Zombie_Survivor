using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : MonoBehaviour
{
    public static StageSystem instance;
    [SerializeField] private Stage[] stages;

    private Stage currentStage;                          // ���� ���̺� ����
    private int currentStageIndex = 1;                // �������� 1���� ���� ex(stage1, stage2 ...)

    // ���̺� ���� ����� ���� Get ������Ƽ (���� ���̺�, �� ���̺�)
    public int CurrentStageIndex
    {
        get => currentStageIndex;
        set => currentStageIndex = value;
    }
    public int MaxStage => stages.Length;   
    public float CurrentLimitTime => stages[currentStageIndex-1].limitTime;     // �������� �ε����� 1���� �����ϴϱ� 1����

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
    //public float spawnTime; // ���� ���̺� �� ���� �ֱ�
    //public int maxEnemyCount;   // ���� ���̺� �� ���� ����
    //public GameObject[] enemyPrefabs; // ���� ���̺� �� ���� ����
    public float limitTime;   // ���� ���̺� ���ѽð�
}