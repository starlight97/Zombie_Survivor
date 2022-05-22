using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletNormal : PlayerBulletBase
{
    public override void CallFire()
    {
        base.CallFire();
    }

    public override void CallFire(float speed, float damage, float range, Vector2 Direction)
    {
        base.CallFire(speed, damage, range, Direction);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void BulletAfterEffect()
    {
        base.BulletAfterEffect();
    }

    protected override void DoFire()
    {
        base.DoFire();
    }
    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void OnHit()
    {
        base.OnHit();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {

        EnemyHealth enemyHealth;    //적 체력 임시.
        collision.TryGetComponent<EnemyHealth>(out enemyHealth);  //적 체력 스크립트 취득 시도.
        if (enemyHealth != null)    //성공시 데미지 부여
            enemyHealth.HitThisObjet(fDamage);


        base.OnTriggerEnter2D(collision);
    }


    protected override void RemoveThisBulelt()
    {
        base.RemoveThisBulelt();
    }

}
