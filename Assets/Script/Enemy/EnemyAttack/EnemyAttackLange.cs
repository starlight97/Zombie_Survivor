using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackLange : EnemyAttackBase
{
    protected bool bCanAttack;  //������ ���ɿ��θ� ����ϴ� bool ����

    /// <summary>
    /// �ʱ� ����.
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
    /// ���ʼ���.
    /// ��Ÿ�� ���� �� ���ݽ����ÿ� ����Ǿ�� �ϴ� �κ��� ����.
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
    /// ������ ������ ����Ǵ� �κ�.
    /// �������� �� �ݶ��̴��� ������ÿ� ����Ǵ� �κ��̿���.
    /// 
    /// �÷��̾� ���� �ݶ��̴��� �̿��Ͽ� �ش� �ݶ��̴��� �÷��̾ �������
    /// ������ ������ �� �� ���Ÿ� ���� ������Ʈ�� �߻��Ѵ�.
    /// </summary>
    /// <param name="collision"></param>
    protected override void Attack(Collider2D collision)
    {
        //base.Attack(collision);
        if(bCanAttack)
        {
            //��Ÿ�� ����
            StartCoroutine(AttackCooltime());
            //���� ���ϸ��̼� ����.
            EnemyAnimation.SetStateAttack();

            //�� LangeObj �����Ͽ� �� ���� ����.

        }
    }

    /// <summary>
    /// ���� ��Ÿ���� ����Ǿ�� �ϴ� �κ�.
    /// ������ ����� �� ȣ��ȴ�. 
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
