using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBase : MonoBehaviour
{
    [SerializeField] protected int Damage;      //플레이어에게 적용될 데미지
    [SerializeField] protected float Radius;    //공격 반경
    [SerializeField] protected float CoolTime;  //공격 쿨타임

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
        WaitCoolTime = new WaitForSeconds(CoolTime);    //실질적 공격 쿨타임이 적용되는 waitforsec
        AttackCircle.radius = Radius;
    }

    /// <summary>
    /// 적 콜라이더에 닿았을시에 공격이 적용되는 부분
    /// 공격의 쿨타임을 적용시켜 적에게 순간적으로 데미지가 적용되지 않도록 해야한다.
    /// </summary>
    protected virtual void Attack(Collision2D collision)
    {
        //공격이 적용되는 부분
        //공격의 데미지 적용

        //공격 쿨타임 적용
        StartCoroutine(AttackCooltime());
    }

    /// <summary>
    /// 공격 쿨타임이 적용되는 부분.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator AttackCooltime()
    {
        DisAbleAttackCollider();
        yield return WaitCoolTime;
        EnAbleAttackCollider();
    }

    /// <summary>
    /// 공격 콜라이더 활성화
    /// </summary>
    protected virtual void EnAbleAttackCollider()
    {
        AttackCircle.enabled = true;
    }

    /// <summary>
    /// 공격 콜라이더 비활성화.
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
