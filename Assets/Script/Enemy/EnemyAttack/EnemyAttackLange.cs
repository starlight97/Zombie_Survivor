using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackLange : EnemyAttackBase
{
    protected bool bCanAttack;  //������ ���ɿ��θ� ����ϴ� bool ����
    protected IEnumerator corAttack;
    
    [SerializeField] protected EnemyLangeObj attackObj;
    protected EnemyLangeObj tmpObj;
    [SerializeField] protected EnemyLangeObjectDataBase attackObjectData;
    /// <summary>
    /// �ʱ� ����.
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

    /// <summary>
    /// ����� ��Ÿ���� �ʱ�ȭ
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
    /// �� ������Ʈ�� �ʱ�ȭ
    /// </summary>
    protected virtual void RestThisObj()
    {
        bCanAttack = false;
    }

    /// <summary>
    /// ������ ������ ����Ǵ� �κ�.
    /// �������� �� �ݶ��̴��� ������ÿ� ����Ǵ� �κ��̿���.
    /// 
    /// �÷��̾� ���� �ݶ��̴��� �̿��Ͽ� �ش� �ݶ��̴��� �÷��̾ �������
    /// ������ ������ �� �� ���Ÿ� ���� ������Ʈ�� �߻��Ѵ�.
    /// 
    /// ������� ������..
    /// </summary>
    /// <param name="collision"></param>
    protected override void Attack(Collider2D collision)
    {
        //base.Attack(collision);
        if(bCanAttack)
        {
            //��Ÿ�� ����
            //StartCoroutine(AttackCooltime(collision));
            //���� ���ϸ��̼� ����.
            EnemyAnimation.SetStateAttack();

            //�� LangeObj �����Ͽ� �� ���� ����.

        }
    }

    /// �÷��̾� ���� �κ�...
    /// �÷��̾��� �������θ� Ȯ���ϰ� �� �ڿ� Stay�� �̿��Ͽ� ����
    ///     ������ ������ �������� ����ó�� �ʿ��� ���ҽ��� ���� ��Ƹ�����
    ///     ������ �����ϰ� ���ҽ� �Ҹ��� �ٸ��� ������.
    /// OnTriggerEnter2D �� OnTriggerExit2D ���� �̿��Ͽ� ����


    /// <summary>
    /// �÷��̾ ���� �Ǿ����� AttackCoolTime�� ����.
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
    /// ���� ��Ÿ���� ����Ǿ�� �ϴ� �κ�.
    /// ������ ����� �� ȣ��ȴ�. 
    /// ...
    /// �÷��̾ ������������ ����ȴ�.
    /// �÷��̾ Ʈ���� ������ ���������� �� ���� ����ȴ�.
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
    /// ���������� ���Ÿ� ����ü�� ������ �ϴ� �Լ�.
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
