using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon01 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private Transform muzzleTransform;
    [SerializeField] 
    private float speed;     //탄의 속도
    [SerializeField] 
    private int damage;    //탄의 데미지
    [SerializeField]
    private float range;     //탄의 사거리
    [SerializeField]
    private int exprosiveRange;     //탄의 폭발 범위
    [SerializeField]
    private float attackDelay;  // 공격 딜레이
    [SerializeField]
    private float exprosiveTime;

    private bool isAttack;
    private WaitForSeconds waitCoolTime;
    public GameObject target = null;


    void Start()
    {
        muzzleTransform = transform.Find("MuzzlePoint");
        waitCoolTime = new WaitForSeconds(attackDelay);    //실질적 공격 쿨타임이 적용되는 waitforsec
        isAttack = false;
    }


    void Update()
    {
        if(!isAttack)
        {
            SpawnBullet();
        }        

        WeaponRotation();     
    }

    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bullet, muzzleTransform.position, transform.rotation);
        clone.GetComponent<Bullet01>().Setup(damage, exprosiveRange, muzzleTransform.position - transform.position, exprosiveTime);
        StartCoroutine("AttackCooltime");
    }

    /// <summary>
    /// 무기 회전 로직
    /// </summary>
    private void WeaponRotation()
    {
        if(target != null)
        {
            Vector3 dir = target.transform.position - transform.position;

            // 타겟 방향으로 회전함
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if(target == null)
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
