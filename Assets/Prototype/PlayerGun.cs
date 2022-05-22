using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] protected PlayerBulletBase NormalBullet;

    [SerializeField] Transform GunMuzzle;

    [SerializeField] protected float fSpeed;     //ÅºÀÇ ¼Óµµ
    [SerializeField] protected float fDamage;    //ÅºÀÇ µ¥¹ÌÁö
    [SerializeField] protected float fRange;     //ÅºÀÇ »ç°Å¸®

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("GunSet");
        InvokeRepeating("TestFire", 1f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void TestFire()
    {

        //Debug.Log("Fire");

        PlayerBulletBase tmpObj = Instantiate(NormalBullet);
        tmpObj.transform.position = GunMuzzle.position;
        tmpObj.CallFire(fSpeed, fDamage, fRange, GunMuzzle.position - this.transform.position);

    }

}
