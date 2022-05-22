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
    private float damage;    //ź�� ������
    [SerializeField] 
    private float range;     //ź�� ��Ÿ�
    [SerializeField]
    private float attackDelay;  // ���� �ӵ�

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

            // Ÿ�� �������� ȸ����
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if(target == null)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }


    }
}
