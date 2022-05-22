using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBodyDataBase", menuName = "Scriptable Object/Enemy Database/EnemyBody Data Base")]
public class EnemyBodyDataBase : ScriptableObject
{

    [Tooltip("���� �ִ� ä���Դϴ�.")]
    [SerializeField] protected int MaxHealth;
    public int MAXHEALTH { get { return MaxHealth; } }

    [Tooltip("���� �̵��ӵ� �Դϴ�..")]
    [SerializeField] protected float Speed;
    public float SPEED { get { return Speed; } }

    [Tooltip("���� ���ݷ� �Դϴ�.")]
    [SerializeField] protected int Damage;
    public int DAMAGE { get { return Damage; } }

    [Tooltip("���� �������� ���� �Դϴ�.")]
    [SerializeField] protected float Radius;
    public float RADIUS { get { return Radius; } }

    [Tooltip("������ ��Ÿ�� �Դϴ�.")]
    [SerializeField] protected float CoolTime;
    public float COOLTIME { get { return CoolTime; } }

}
