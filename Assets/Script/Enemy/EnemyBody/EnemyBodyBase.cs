using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� �ٵ� ���� ���̽��Դϴ�.
/// �̰������� ���� ü��, 
/// </summary>
//[RequireComponent(typeof(EnemyBodyDataBase))]
public class EnemyBodyBase : MonoBehaviour
{
    //���� ������
    [SerializeField] protected EnemyBodyDataBase bodydata;
    [SerializeField] protected EnemyAIBase EnemyAI;
    [SerializeField] protected EnemyAttackBase EnemyAttack;

    [SerializeField] protected int MaxHealth;   //�ִ� ä��.
    protected int CurrentHealth;                //���� ä��.
    

    protected virtual void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// �ʱ�ȭ�� �Լ�.
    /// </summary>
    protected virtual void Initialize()
    {
        //ä�� �ʱ�ȭ
        MaxHealth = bodydata.MAXHEALTH;
        CurrentHealth = MaxHealth;

        //�ӵ� ����
        EnemyAI.SetUp(bodydata.SPEED, bodydata.RADIUS);
        EnemyAttack.SetUp(bodydata.DAMAGE, bodydata.RADIUS, bodydata.COOLTIME);

    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {

    }
    protected virtual void FixedUpdate()
    {

    }

    /// <summary>
    /// �ش� ������Ʈ�� Ÿ�ݽÿ� �θ� �Լ�.
    /// Damage�� �����Ѵ�.
    /// </summary>
    /// <param name="Damage"></param>
    public virtual void GetDamaged(int Damage)
    {
        if(0 < CurrentHealth - Damage)
        {
            CurrentHealth -= Damage;
        }
        else
        {
            CurrentHealth = 0;
            DeadThisUnit();
        }
    }

    protected virtual void DeadThisUnit()
    {

    }

}
