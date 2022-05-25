using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon01 : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private Transform muzzleTransform;
    [SerializeField] 
    private float speed;     //ź�� �ӵ�
    [SerializeField] 
    private int damage;    //ź�� ������
    [SerializeField]
    private float range;     //ź�� ��Ÿ�
    [SerializeField]
    private int exprosiveRange;     //ź�� ���� ����
    [SerializeField]
    private float attackDelay;  // ���� ������
    [SerializeField]
    private float exprosiveTime;

    private bool isAttack;
    private WaitForSeconds waitCoolTime;
    public GameObject target = null;


    void Start()
    {
        muzzleTransform = transform.Find("MuzzlePoint");
        waitCoolTime = new WaitForSeconds(attackDelay);    //������ ���� ��Ÿ���� ����Ǵ� waitforsec
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
    /// ���� ȸ�� ����
    /// </summary>
    private void WeaponRotation()
    {
        if(target != null)
        {
            Vector3 dir = target.transform.position - transform.position;

            // Ÿ�� �������� ȸ����
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
