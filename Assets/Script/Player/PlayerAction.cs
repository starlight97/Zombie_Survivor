using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Vector2 dirVec;     // ���� �÷��̾ �����ִ� ����
    private float rayLength = 1f;    // ���� ����(���� ����)
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

        // ��ĵ�� ������Ʈ�� �ִٸ�
        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
            Action();
        }
        // ��ĵ�� ������Ʈ�� ���ٸ�
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
