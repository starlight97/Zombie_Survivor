using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHP playerHP;
    private PlayerMove playerMove;
    private PlayerAction playerAction;

    private float horizontal;   // ���� �Է� ���� ����
    private float vertical;     // ���� �Է� ���� ����
    private Vector2 dirVec;     // ���� �÷��̾ �����ִ� ����



    void Start()
    {        
        Setup();
        
    }

    void Update()
    {
        GetInput();
        SetDirVec();
    }

    private void Setup()
    {
        playerHP = GetComponent<PlayerHP>();
        playerMove = GetComponent<PlayerMove>();
        playerAction = GetComponent<PlayerAction>();
    }

    /// <summary>
    /// Ű���� Ű�Է� ó�� �Լ�
    /// </summary>
    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        playerMove.Vertical = vertical;
        playerMove.Horizontal = horizontal;

        // �����̽�Ű �Է½� �÷��̾� ���� ��ĵ�� ������Ʈ�� �ִٸ� ������Ʈ ���� ����
        if(Input.GetButtonDown("Jump"))
        {
            playerAction.ScanObject();
        }
    }

    /// <summary>
    /// ���� �÷��̾ ���� �ִ¹��� ����
    /// horizontal, vertical Ű���� ����Ű �ϳ��� �Է� ������쿡�� �����ִ� ���� ����
    /// </summary>
    private void SetDirVec()
    {
        if (horizontal != 0 || vertical != 0)
        {
            dirVec = new Vector2(horizontal, vertical);
            playerAction.DirVec = dirVec;
        }
    }

    


}
