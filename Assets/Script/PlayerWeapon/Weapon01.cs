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
    private float damage;    //탄의 데미지
    [SerializeField] 
    private float range;     //탄의 사거리
    [SerializeField]
    private float attackDelay;  // 공격 속도

    private float currentTime;
    public GameObject target = null;


    void Start()
    {
        muzzleTransform = transform.Find("MuzzlePoint");
    }


    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > attackDelay)
        {
            //SpawnBullet();
        }


        WeaponRotation();
     
    }

    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bullet, muzzleTransform.position, transform.rotation);
        clone.GetComponent<Bullet01>().Setup(10f, muzzleTransform.position - transform.position);
        currentTime = 0f;
    }

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
}
