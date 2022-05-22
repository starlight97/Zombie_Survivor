using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 적 바디에 대한 베이스입니다.
/// 이곳에서는 적의 체력, 
/// </summary>
//[RequireComponent(typeof(EnemyBodyDataBase))]
public class EnemyBodyBase : MonoBehaviour
{
    //적의 데이터
    [SerializeField] protected EnemyBodyDataBase bodydata;
    [SerializeField] protected EnemyAIBase EnemyAI;
    [SerializeField] protected EnemyAttackBase EnemyAttack;

    [SerializeField] protected int MaxHealth;   //최대 채력.
    protected int CurrentHealth;                //현제 채력.
    

    protected virtual void Awake()
    {
        Initialize();
    }

    /// <summary>
    /// 초기화용 함수.
    /// </summary>
    protected virtual void Initialize()
    {
        //채력 초기화
        MaxHealth = bodydata.MAXHEALTH;
        CurrentHealth = MaxHealth;

        //속도 설정
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
    /// 해당 오브젝트를 타격시에 부를 함수.
    /// Damage를 전달한다.
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
