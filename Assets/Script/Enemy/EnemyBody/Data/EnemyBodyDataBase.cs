using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBodyDataBase", menuName = "Scriptable Object/Enemy Database/EnemyBody Data Base")]
public class EnemyBodyDataBase : ScriptableObject
{

    [Tooltip("적의 최대 채력입니다.")]
    [SerializeField] protected int MaxHealth;
    public int MAXHEALTH { get { return MaxHealth; } }

    [Tooltip("적의 이동속도 입니다..")]
    [SerializeField] protected float Speed;
    public float SPEED { get { return Speed; } }

    [Tooltip("적의 공격력 입니다.")]
    [SerializeField] protected int Damage;
    public int DAMAGE { get { return Damage; } }

    [Tooltip("적의 근접공격 범위 입니다.")]
    [SerializeField] protected float Radius;
    public float RADIUS { get { return Radius; } }

    [Tooltip("공격의 쿨타임 입니다.")]
    [SerializeField] protected float CoolTime;
    public float COOLTIME { get { return CoolTime; } }

}
