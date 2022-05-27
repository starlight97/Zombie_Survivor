using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Vector2 dirVec;     // 현재 플레이어가 보고있는 방향
    private float rayLength = 1f;    // 레이 길이(조사 범위)
    private GameObject scanObject;
    private GameManager gameManager;

    public Vector2 DirVec
    {
        set => dirVec = value;
    }

    private void Start()
    {
        Setup();
    }

    public void ScanObject()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, dirVec, rayLength, LayerMask.GetMask("Object"));        

        // 스캔된 오브젝트가 있다면
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            Action();
        }
        // 스캔된 오브젝트가 없다면
        else
        {
            scanObject = null;
        }
        
    }

    private void Action()
    {
        if (scanObject.name == "Switch")
        {            
            gameManager.WaveStart();
        }
    }

    private void Setup()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
