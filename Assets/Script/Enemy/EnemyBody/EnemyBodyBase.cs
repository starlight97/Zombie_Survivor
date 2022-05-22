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

    [SerializeField] protected HealthBar healthBar;

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

    /// <summary>
    /// 타 오브젝트에서 해당 오브젝트의 데미지 정보를
    /// 받아가기 위한 함수
    /// </summary>
    /// <returns></returns>
    public virtual int AnotherGetDamage()
    {
        return bodydata.DAMAGE;
    }


    /// <summary>
    /// 채력바 업데이트
    /// </summary>
    public void UpdateHealthBar()
    {
        healthBar.EditBar(MaxHealth, CurrentHealth);
    }

    protected virtual void DeadThisUnit()
    {

    }

    /// <summary>
    /// 전리품을 드롭하는 함수.
    /// 씬에 준비된 전리품 오브젝트 풀에서 준비된 
    /// 오브젝트를 꺼내 사용하도록 한다.
    /// </summary>
    protected virtual void DropLoot()
    {

    }

}
