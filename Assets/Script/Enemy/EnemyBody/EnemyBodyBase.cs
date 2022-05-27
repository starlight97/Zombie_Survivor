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
    //적 에니메이션 스크립트.
    [SerializeField] protected EnemyAnimationBase EnemyAnimation;

    //적 경험치 오브젝트 풀
    [SerializeField] public DropItemObjectPool ObjectPool;

    [SerializeField] protected HealthBar healthBar;

    [SerializeField] protected int MaxHealth;   //최대 채력.
    protected int CurrentHealth;                //현제 채력.
    protected bool isAlive;

    protected IEnumerator corDotDamage; //지속적인 도트데미지를 주기 위한 corDotDamage...
    [Tooltip("DotDamage이 적용되는 중 사이의 인터벌 값입니다.")]
    [SerializeField] protected float fDotWaitTime;
    protected WaitForSeconds DotWaitTime;
    protected IEnumerator corSpeededit;
    protected IEnumerator corMaxhealthReduction;

    //최대 채력 데미지에 사용할 변수
    protected int circulateDamage;

    //임시변수
    public float TestFloat;
    //임시변수

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
        isAlive = true;

        //속도 설정
        EnemyAI.SetUp(bodydata.SPEED, bodydata.RADIUS);
        EnemyAttack.SetUp(bodydata.DAMAGE, bodydata.RADIUS, bodydata.COOLTIME);
        DotWaitTime = new WaitForSeconds(fDotWaitTime);
        if (EnemyAnimation == null) //적 에니메이션 스크립트가 달려있지 않을시 취득 시도.
        {
            EnemyAnimation = GetComponent<EnemyAnimationBase>();
#if UNITY_EDITOR
            Debug.LogError("This Object has not EnemyAnimationBase\nTry Get Component...");
#endif
        }
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetDotDamaged(10, 3, 10);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetDotDamaged(10, 3, 10,0.1f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GetSpeedEditEffect(0.5f, 3);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetMaxHealthPerDamage(TestFloat);
        }
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
        if (isAlive)
        {
            if (0 < CurrentHealth - Damage)
            {
                CurrentHealth -= Damage;
            }
            else
            {
                CurrentHealth = 0;
                isAlive = false;
                Debug.Log("Dead!!");
                DeadThisUnit();
            }

            //헬스바 업데이트.
            UpdateHealthBar();
        }
    }

    /// <summary>
    /// 피격시 데미지, 타입만 전달.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="Type"></param>
    public virtual void GetDamaged(int Damage, Debuff Type)
    {
        //기본 피격 데미지...
        GetDamaged(Damage);



    }

    /// <summary>
    /// 피격시 데미지, 타입, 도트데미지를 전달.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="Type"></param>
    /// <param name="DotDamage"></param>
    public virtual void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime )
    {
        //기본 피격 데미지 적용...
        GetDamaged(Damage);

        //DotDamage일시.
        //DotDamage 부여 실시..
        switch (Type)
        {
            case Debuff.Normal:
                break;
            case Debuff.Slow:
                break;
            case Debuff.MaxHealthDown:
                break;

                //지속데미지
            case Debuff.DotDamage:
                if (corDotDamage != null)
                {
                    StopCoroutine(corDotDamage);
                }
                corDotDamage = CorFuncDotDamage(DotDamage, HoldTime);
                StartCoroutine(corDotDamage);
                break;
            default:
                break;
        }

    }
    public virtual void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime, float Interval)
    {
        //기본 피격 데미지 적용...
        GetDamaged(Damage);
        //DotDamage일시.
        //DotDamage 부여 실시..
        switch (Type)
        {
            case Debuff.Normal:
                break;
            case Debuff.Slow:
                break;
            case Debuff.MaxHealthDown:
                break;

            //지속데미지
            case Debuff.DotDamage:
                if (corDotDamage != null)
                {
                    StopCoroutine(corDotDamage);
                }
                corDotDamage = CorFuncDotDamage(DotDamage, HoldTime, Interval);
                StartCoroutine(corDotDamage);
                break;
            default:
                break;
        }

    }

    //도트데미지 관련
    /// <summary>
    /// 도트 데미지를 부여할 때 사용하는 함수이다.
    /// Damage는 피격시에 즉시 대미지가 적용된다.
    /// DotDamage는 도트 데미지이다.
    /// HoldCyle은 유지될 회차이다. 기본 설정은 회차당 1초다.
    /// Interval은 이 회차당 시간 간격을 줄이는 부분이다.
    /// </summary>
    /// <param name="Damage"></param>
    /// <param name="DotDamage"></param>
    /// <param name="HoldCycle"></param>
    /// <param name="Interval"></param>
    public virtual void GetDotDamaged(int Damage, int DotDamage, int HoldCycle, float Interval = 1f)
    {
        GetDamaged(Damage);             //즉시 데미지 적용.
        if (corDotDamage != null)
        {
            StopCoroutine(corDotDamage);
        }
        if (Mathf.Approximately(Interval, 1f))  //기본으로 Interval에 설정된 1f값이 아닌 다른 값이 들어왔을 경우..
            corDotDamage = CorFuncDotDamage(DotDamage, HoldCycle);  //1f 일경우
        else
            corDotDamage = CorFuncDotDamage(DotDamage, HoldCycle, Interval);    //1f가 아닐경우
        StartCoroutine(corDotDamage);   //실행.
    }

    //슬로우 관련
    /// <summary>
    /// Slow Effect.
    /// per는 기존의 속도에 곱해질 값입니다.
    /// HoldTime은 유지될 시간입니다. int를 사용해서 초 단위로 정합니다.
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    public virtual void GetSpeedEditEffect(float per, int HoldTime)
    {
        if (corSpeededit != null)
            StopCoroutine(corSpeededit);
        corSpeededit = CorFuncSpeedEdit(per, HoldTime);
        StartCoroutine(corSpeededit);

    }
    protected IEnumerator CorFuncSpeedEdit(float per,int HoldTime)
    {
        //속도 감소 적용
        EnemyAI.ModifydeSpeed(per);
        EnemyAttack.ModifydeAttackCooltime(per);
        for (int i = 0; i < HoldTime; i++)
        {
            yield return DotWaitTime;
        }
        //속도 감소 되돌리기.
        EnemyAI.UndoSpeed();
        EnemyAttack.UndoAttackCooltime();
    }

    //최대 체력 비례 데미지
    /// <summary>
    /// 최대 체력 비례 데미지.
    /// </summary>
    /// <param name="per"></param>
    public virtual void GetMaxHealthPerDamage(float per)
    {
        circulateDamage = (int)((float)MaxHealth * per);
        GetDamaged(circulateDamage);
    }

    //최대 채력 감소 관련
    /// <summary>
    /// 최대 채력을 per만큼 곱하여 최대 채력을 줄이는 함수 입니다.
    /// Holdtime은 유지될 시간입니다. int를 사용하여 초 단위로 정합니다.
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    public virtual void GetMaxhealthReduction(float per, int HoldTime)
    {
        if (corMaxhealthReduction != null)
            StopCoroutine(corMaxhealthReduction);
        corMaxhealthReduction = CorFuncMaxhealthReduction(per, HoldTime);
        StartCoroutine(corMaxhealthReduction);
    }
    protected IEnumerator CorFuncMaxhealthReduction(float per, int HoldTime)
    {
        //채력 감소 적용
        for (int i = 0; i < HoldTime; i++)
        {
            yield return DotWaitTime;
        }
        //채력 감소 되돌리기.
    }

    /// <summary>
    /// 지속적인 도트데미지를 해당 오브젝트에게 주기 위한 부분.
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    protected virtual IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime)
    {
        //HoldTime 만큼 반복.
        //새로운 효과를 받을 시 초기화된 후 새로 받은 효과가 적용된다...
        for (int i = 0; i < HoldTime; i++)
        {
            //데미지 적용
            GetDamaged(DotDamage);
            //휴식
            yield return DotWaitTime;
        }
    }
    protected virtual IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime, float Interval)
    {
        WaitForSeconds tmpWait = new WaitForSeconds(Interval);
        //HoldTime 만큼 반복.
        //새로운 효과를 받을 시 초기화된 후 새로 받은 효과가 적용된다...
        for (int i = 0; i < HoldTime; i++)
        {
            //데미지 적용
            GetDamaged(DotDamage);
            //휴식
            yield return tmpWait;
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

    public void ResetHealth()
    {
        isAlive = true;
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    protected virtual void DeadThisUnit()
    {
        DropLoot();

        EnemyAnimation.SetStateDead();

        //비활성화 오브젝트 풀링시에 해당 풀로 복귀
        ObjectPool.CallFunc_DropEXP(this.transform, 1);
        EnemyAI.RetrunStackThis();
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 전리품을 드롭하는 함수.
    /// 씬에 준비된 전리품 오브젝트 풀에서 준비된 
    /// 오브젝트를 꺼내 사용하도록 한다.
    /// </summary>
    protected virtual void DropLoot()
    {
        Debug.Log("DROP LOOT!");
    }

}
