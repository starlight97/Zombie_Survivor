using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBase : MonoBehaviour
{
    [SerializeField] protected int Damage;      //�÷��̾�� ����� ������
    [SerializeField] protected float Radius;    //���� �ݰ�
    [SerializeField] protected float CoolTime;  //���� ��Ÿ��

    protected WaitForSeconds WaitCoolTime;

    [SerializeField] protected CircleCollider2D AttackCircle;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void Initialize()
    {
        
    }

    public virtual void SetUp(int mDamage, float mRadius, float mCoolTime)
    {
        Damage = mDamage;
        Radius = mRadius;
        CoolTime = mCoolTime;
        WaitCoolTime = new WaitForSeconds(CoolTime);    //������ ���� ��Ÿ���� ����Ǵ� waitforsec
        AttackCircle.radius = Radius;
    }

    /// <summary>
    /// �� �ݶ��̴��� ������ÿ� ������ ����Ǵ� �κ�
    /// ������ ��Ÿ���� ������� ������ ���������� �������� ������� �ʵ��� �ؾ��Ѵ�.
    /// </summary>
    protected virtual void Attack(Collision2D collision)
    {
        //������ ����Ǵ� �κ�
        //������ ������ ����

        //���� ��Ÿ�� ����
        StartCoroutine(AttackCooltime());
    }

    /// <summary>
    /// ���� ��Ÿ���� ����Ǵ� �κ�.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator AttackCooltime()
    {
        DisAbleAttackCollider();
        yield return WaitCoolTime;
        EnAbleAttackCollider();
    }

    /// <summary>
    /// ���� �ݶ��̴� Ȱ��ȭ
    /// </summary>
    protected virtual void EnAbleAttackCollider()
    {
        AttackCircle.enabled = true;
    }

    /// <summary>
    /// ���� �ݶ��̴� ��Ȱ��ȭ.
    /// </summary>
    protected virtual void DisAbleAttackCollider()
    {
        AttackCircle.enabled = false;
    }

    /// <summary>
    /// Collition Stay...
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionStay2D(Collision2D collision)
    {
        Attack(collision);
    }


}
