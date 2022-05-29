using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Ÿ� ���� ������Ʈ�� ������ �ϴ� ����
/// �ӵ�, ���� ����ü�� ũ��, 
/// </summary>
[CreateAssetMenu(fileName = "Enemy LangeObj DataBase", menuName = "Scriptable Object/Enemy Database/Enemy Lange Object DataBase")]
public class EnemyLangeObjectDataBase : ScriptableObject
{
    [Tooltip("����ü�� �ӵ��Դϴ�.\n���� �־�鼭 ������ ���� ã�ƺ���~")]
    [SerializeField] protected float Speed;
    public float SPEED { get { return Speed; }}

    [Tooltip("������Ʈ�� Ȱ��ȭ �ð��Դϴ�.")]
    [SerializeField] protected float LifeTime;
    public float LIFETIME { get { return LifeTime; } }

    [Tooltip("���Ÿ� ���� ����ü�� ������ �Դϴ�.\n�������� �����ϸ鼭 ũ�⸦ �ٲߴϴ�.")]
    [SerializeField] protected float Scale;
    public float SCALE { get { return Scale; }}

}
