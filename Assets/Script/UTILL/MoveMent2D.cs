using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveDirection = Vector3.zero;

    public float MoveSpeed => moveSpeed;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
    public void MoveStop()
    {
        moveSpeed = 0;
    }
}
