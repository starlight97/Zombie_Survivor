using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ������ �ϴ� ��.
/// ���� �κ��� ���� �ʿ�.
/// �̵����� AI���� ��ӹ޾� ���� �ʿ�.
/// </summary>
public class EnemyBodyLange : EnemyBodyBase
{
    public override int AnotherGetDamage()
    {
        return base.AnotherGetDamage();
    }

    public override void GetDamaged(int Damage)
    {
        base.GetDamaged(Damage);
    }

    public override void GetDamaged(int Damage, Debuff Type)
    {
        base.GetDamaged(Damage, Type);
    }

    public override void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime)
    {
        base.GetDamaged(Damage, Type, DotDamage, HoldTime);
    }

    public override void GetDamaged(int Damage, Debuff Type, int DotDamage, int HoldTime, float Interval)
    {
        base.GetDamaged(Damage, Type, DotDamage, HoldTime, Interval);
    }

    public override void GetDotDamaged(int Damage, int DotDamage, int HoldCycle, float Interval = 1)
    {
        base.GetDotDamaged(Damage, DotDamage, HoldCycle, Interval);
    }

    public override void GetMaxHealthPerDamage(float per)
    {
        base.GetMaxHealthPerDamage(per);
    }

    public override void GetMaxhealthReduction(float per, int HoldTime)
    {
        base.GetMaxhealthReduction(per, HoldTime);
    }

    /// <summary>
    /// ������ ����ϴ� �ӵ����� �Լ��� ���Ÿ� ���ݿ� �°� ����...
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    public override void GetSpeedEditEffect(float per, int HoldTime)
    {
        //base.GetSpeedEditEffect(per, HoldTime);
        if (corSpeededit != null)
            StopCoroutine(corSpeededit);
        corSpeededit = CorFuncSpeedEdit(per, HoldTime);
        StartCoroutine(corSpeededit);
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime)
    {
        return base.CorFuncDotDamage(DotDamage, HoldTime);
    }

    protected override IEnumerator CorFuncDotDamage(int DotDamage, int HoldTime, float Interval)
    {
        return base.CorFuncDotDamage(DotDamage, HoldTime, Interval);
    }

    protected override IEnumerator CorFuncMaxhealthReduction(float per, int HoldTime)
    {
        return base.CorFuncMaxhealthReduction(per, HoldTime);
    }

    /// <summary>
    /// ���Ÿ� ���� Ÿ�Կ� �°� ����Ǿ����
    /// </summary>
    /// <param name="per"></param>
    /// <param name="HoldTime"></param>
    /// <returns></returns>
    protected override IEnumerator CorFuncSpeedEdit(float per, int HoldTime)
    {
        EnemyAI.ModifydeSpeed(per);
        EnemyAttack.ModifydeAttackCooltime(per);
        for (int i = 0; i < HoldTime; i++)
        {
            yield return DotWaitTime;
        }
        //�ӵ� ���� �ǵ�����.
        EnemyAI.UndoSpeed();
        EnemyAttack.UndoAttackCooltime();
    }

    protected override void DeadThisUnit()
    {
        base.DeadThisUnit();
    }

    protected override void DropLoot()
    {
        base.DropLoot();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Initialize()
    {
        base.Initialize();
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
