using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenadeLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;   // 총알 생성을 위한 프리팹
    [SerializeField] private float speed;               // 탄의 속도
    [SerializeField] private int damage;                // 탄의 데미지
    [SerializeField] private float range;               // 탄의 사거리
    [SerializeField] private int exprosiveRange;        // 탄의 폭발 범위
    [SerializeField] private float attackDelay;         // 공격 딜레이
    [SerializeField] private float exprosiveTime;       // 폭발 시간
    private Transform muzzleTransform;                  // 총알이 소환될 무기 포구
    private EnemyRader enemyRader;

    private bool isAttack;
    private WaitForSeconds waitCoolTime;
    private GameObject target;

    void Start()
    {
        Setup();
    }


    void Update()
    {
        if (!isAttack)
        {
            SpawnBullet();
        }

        WeaponRotation();
    }
    private void Setup()
    {
        muzzleTransform = transform.Find("MuzzlePoint");
        waitCoolTime = new WaitForSeconds(attackDelay);
        isAttack = false;
        enemyRader = this.transform.parent.Find("EnemyRader").GetComponent<EnemyRader>();
    }

    /// <summary>
    /// 총알 생성 스크립트
    /// </summary>
    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bulletPrefab, muzzleTransform.position, transform.rotation);
        // 총알 방향은 포구위치 - 플레이어위치를 하면 구할수 있습니다.
        Vector3 direction = muzzleTransform.position - transform.position;
        clone.GetComponent<Bullet01>().Setup(damage, exprosiveRange, direction, exprosiveTime);
        StartCoroutine("AttackCooltime");
    }

    /// <summary>
    /// 무기 회전 스크립트
    /// </summary>
    private void WeaponRotation()
    {
        target = enemyRader.Target;
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;

            // 타겟 방향으로 회전함
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (target == null)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    private IEnumerator AttackCooltime()
    {
        isAttack = true;
        yield return waitCoolTime;
        isAttack = false;
    }


}

/*
 * 유탄발사기 무기 스크립트 입니다.
 * 
 * 
 * 
 * 
 * 
*/