using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGrenadeLauncher : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;   // �Ѿ� ������ ���� ������
    [SerializeField] private float speed;               // ź�� �ӵ�
    [SerializeField] private int damage;                // ź�� ������
    [SerializeField] private float range;               // ź�� ��Ÿ�
    [SerializeField] private int exprosiveRange;        // ź�� ���� ����
    [SerializeField] private float attackDelay;         // ���� ������
    [SerializeField] private float exprosiveTime;       // ���� �ð�
    private Transform muzzleTransform;                  // �Ѿ��� ��ȯ�� ���� ����
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
    /// �Ѿ� ���� ��ũ��Ʈ
    /// </summary>
    private void SpawnBullet()
    {
        GameObject clone = Instantiate(bulletPrefab, muzzleTransform.position, transform.rotation);
        // �Ѿ� ������ ������ġ - �÷��̾���ġ�� �ϸ� ���Ҽ� �ֽ��ϴ�.
        Vector3 direction = muzzleTransform.position - transform.position;
        clone.GetComponent<Bullet01>().Setup(damage, exprosiveRange, direction, exprosiveTime);
        StartCoroutine("AttackCooltime");
    }

    /// <summary>
    /// ���� ȸ�� ��ũ��Ʈ
    /// </summary>
    private void WeaponRotation()
    {
        target = enemyRader.Target;
        if (target != null)
        {
            Vector3 dir = target.transform.position - transform.position;

            // Ÿ�� �������� ȸ����
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
 * ��ź�߻�� ���� ��ũ��Ʈ �Դϴ�.
 * 
 * 
 * 
 * 
 * 
*/