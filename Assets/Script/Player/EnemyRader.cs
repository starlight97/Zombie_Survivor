using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRader : MonoBehaviour
{
    private GameObject target;

    public GameObject Target => target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            target = collision.gameObject;
        }
    }

}
