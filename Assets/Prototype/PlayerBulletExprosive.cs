using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletExprosive : PlayerBulletBase
{
    [Tooltip("폭발 반경입니다.")]
    [SerializeField] protected float Radius;
    [SerializeField] protected CircleCollider2D collider2D;
    [SerializeField] protected GameObject explosiveBoom;

    public override void CallFire()
    {
        base.CallFire();
    }

    public override void CallFire(float speed, float damage, float range, Vector2 Direction)
    {
        base.CallFire(speed, damage, range, Direction);
    }

    protected override void Awake()
    {
        base.Awake();

        //this.transform.localScale = Vector3.one * Radius;

        collider2D = GetComponent<CircleCollider2D>();
        //collider2D.radius = Radius;
    }

    protected override void BulletAfterEffect()
    {
        base.BulletAfterEffect();
    }

    protected override IEnumerator CorFuncRemoveThisBullet()
    {
        return base.CorFuncRemoveThisBullet();
    }

    protected override void DoFire()
    {
        base.DoFire();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void OnHit()
    {
        Instantiate(explosiveBoom).GetComponent<Explosive>().SetObject(fDamage, Radius, this.gameObject.transform);
        base.OnHit();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void RemoveThisBulelt()
    {
        base.RemoveThisBulelt();
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
