using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 원거리 공격 오브젝트가 가져야 하는 정보
/// 속도, 공격 투사체의 크기, 
/// </summary>
[CreateAssetMenu(fileName = "Enemy LangeObj DataBase", menuName = "Scriptable Object/Enemy Database/Enemy Lange Object DataBase")]
public class EnemyLangeObjectDataBase : ScriptableObject
{
    [Tooltip("투사체의 속도입니다.\n값을 넣어보면서 최적의 값을 찾아봐용~")]
    [SerializeField] protected float Speed;
    public float SPEED { get { return Speed; }}

    [Tooltip("오브젝트의 활성화 시간입니다.")]
    [SerializeField] protected float LifeTime;
    public float LIFETIME { get { return LifeTime; } }

    [Tooltip("원거리 공격 투사체의 스케일 입니다.\n스케일을 조정하면서 크기를 바꿉니다.")]
    [SerializeField] protected float Scale;
    public float SCALE { get { return Scale; }}

}
