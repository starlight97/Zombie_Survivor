using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackLange : EnemyAttackBase
{
    protected bool bCanAttack;  //공격의 가능여부를 기록하는 bool 변수

    /// <summary>
    /// 초기 설정.
    /// </summary>
    protected override void Initialize()
    {
        base.Initialize();

        bCanAttack = true;
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

    public override void UndoAttackCooltime()
    {
        base.UndoAttackCooltime();
    }

    /// <summary>
    /// 실질적 공격이 적용되는 부분.
    /// 이전에는 적 콜라이더가 닿았을시에 실행되는 부분이였다.
    /// 
    /// 플레이어 감지 콜라이더를 이용하여 해당 콜라이더에 플레이어가 닿았을시
    /// 공격이 가능할 때 에 원거리 공격 오브젝트를 발사한다.
    /// </summary>
    /// <param name="collision"></param>
    protected override void Attack(Collider2D collision)
    {
        //base.Attack(collision);
        if(bCanAttack)
        {
            //쿨타임 적용
            StartCoroutine(AttackCooltime());
            //공격 에니메이션 적용.
            EnemyAnimation.SetStateAttack();

            //적 LangeObj 생성하여 값 기초 설정.

        }
    }

    /// <summary>
    /// 공격 쿨타임이 적용되어야 하는 부분.
    /// 공격이 실행될 때 호출된다. 
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator AttackCooltime()
    {
        //return base.AttackCooltime();
        bCanAttack = false;
        yield return WaitCoolTime;
        bCanAttack = true;

        EnemyAnimation.SetStateMove();
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
