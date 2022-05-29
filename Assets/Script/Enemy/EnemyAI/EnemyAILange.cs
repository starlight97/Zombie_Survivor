using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAILange : EnemyAIBase
{

    [SerializeField] protected float fCoolTime;

    public override void SetUp(float getSpeed, float getAttackRadius)
    {
        base.SetUp(getSpeed, getAttackRadius);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void Movement()
    {
        base.Movement();
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
