using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHP playerHP;
    GameObject enemyRader;
    
       
    // Start is called before the first frame update
    void Start()
    {
        // ±êÇéÅ×½ºÆ®
        playerHP = GetComponent<PlayerHP>();
        enemyRader = GameObject.Find("EnemyRader");
    }

    // Update is called once per frame
    void Update()
    {
        //enemyRader
    }

    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.CompareTag("Enemy"))
        {
            playerHP.TakeDamage(10);
        }
    }


}
