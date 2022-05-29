using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackLange : EnemyAttackBase
{
    protected bool bCanAttack;  //공격의 가능여부를 기록하는 bool 변수
    protected IEnumerator corAttack;
    
    [SerializeField] protected EnemyLangeObj attackObj;
    protected EnemyLangeObj tmpObj;
    [SerializeField] protected EnemyLangeObjectDataBase attackObjectData;
    /// <summary>
    /// 초기 설정.
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();

        bCanAttack = true;

#if UNITY_EDITOR
        if (attackObj == null)
            Debug.LogError("Lange Attack Object is NULL!!");
#endif

    }

    public override void ModifydeAttackCooltime(float per)
    {
        base.ModifydeAttackCooltime(per);
    }
    /// <summary>
    /// 기초설정.
    /// 쿨타임 설정 및 공격시전시에 변경되어야 하는 부분이 존재.
    /// </summary>
    /// <param name="mDamage"></param>
    /// <param name="mRadius"></param>
    /// <param name="mCoolTime"></param>
    public override void SetUp(int mDamage, float mRadius, float mCoolTime)
    {
        base.SetUp(mDamage, mRadius, mCoolTime);
    }

    /// <summary>
    /// 변경된 쿨타임을 초기화
    /// </summary>
    public override void UndoAttackCooltime()
    {
        base.UndoAttackCooltime();
    }

    protected virtual void OnDisable()
    {
        RestThisObj();
    }

    /// <summary>
    /// 이 오브젝트를 초기화
    /// </summary>
    protected virtual void RestThisObj()
    {
        bCanAttack = false;
    }

    /// <summary>
    /// 실질적 공격이 적용되는 부분.
    /// 이전에는 적 콜라이더가 닿았을시에 실행되는 부분이였다.
    /// 
    /// 플레이어 감지 콜라이더를 이용하여 해당 콜라이더에 플레이어가 닿았을시
    /// 공격이 가능할 때 에 원거리 공격 오브젝트를 발사한다.
    /// 
    /// 사용하지 않을듯..
    /// </summary>
    /// <param name="collision"></param>
    protected override void Attack(Collider2D collision)
    {
        //base.Attack(collision);
        if(bCanAttack)
        {
            //쿨타임 적용
            //StartCoroutine(AttackCooltime(collision));
            //공격 에니메이션 적용.
            EnemyAnimation.SetStateAttack();

            //적 LangeObj 생성하여 값 기초 설정.

        }
    }

    /// 플레이어 감지 부분...
    /// 플레이어의 감지여부를 확인하고 그 뒤에 Stay를 이용하여 공격
    ///     좀비의 물량이 많을수록 물리처리 쪽에서 리소스를 많이 잡아먹을듯
    ///     기존의 좀비하고 리소스 소모량이 다르진 않을듯.
    /// OnTriggerEnter2D 와 OnTriggerExit2D 만을 이용하여 공격


    /// <summary>
    /// 플레이어가 감지 되었을시 AttackCoolTime을 실행.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bCanAttack = true;
            if(corAttack != null)
                StopCoroutine(corAttack);
            corAttack = AttackCooltime(collision);
            StartCoroutine(corAttack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            bCanAttack = false;
            if (corAttack != null)
                StopCoroutine(corAttack);
        }
    }

    /// <summary>
    /// 공격 쿨타임이 적용되어야 하는 부분.
    /// 공격이 실행될 때 호출된다. 
    /// ...
    /// 플레이어를 감지했을때에 실행된다.
    /// 플레이어가 트리거 범위를 빠져나가기 전 까지 실행된다.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator AttackCooltime(Collider2D collision)
    {
        //return base.AttackCooltime();
        while (bCanAttack == true)
        {
            Ejection(collision.gameObject.transform.position);
            EnemyAnimation.SetStateAttack();

            yield return WaitCoolTime;

            EnemyAnimation.SetStateMove();
        }
    }
    /// <summary>
    /// 실질적으로 원거리 투사체를 나가게 하는 함수.
    /// </summary>
    protected virtual void Ejection(Vector3 position)
    {
        tmpObj = Instantiate(attackObj);
        tmpObj.transform.position = attackObj.transform.position;
        tmpObj.SetUp(attackObjectData.SPEED, attackObjectData.LIFETIME, Damage);
        tmpObj.transform.localScale = new Vector3(attackObjectData.SCALE, attackObjectData.SCALE, 1);

        tmpObj.OnFire(position);

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
