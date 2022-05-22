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

        EnemyHealth enemyHealth;    //�� ü�� �ӽ�.
        collision.TryGetComponent<EnemyHealth>(out enemyHealth);  //�� ü�� ��ũ��Ʈ ��� �õ�.
        if (enemyHealth != null)    //������ ������ �ο�
            enemyHealth.HitThisObjet(fDamage);


        base.OnTriggerEnter2D(collision);
    }


    protected override void RemoveThisBulelt()
    {
        base.RemoveThisBulelt();
    }

}
