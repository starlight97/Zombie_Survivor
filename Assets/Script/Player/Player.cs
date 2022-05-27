using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHP playerHP;
    private PlayerMove playerMove;
    private PlayerAction playerAction;

    private float horizontal;   // 가로 입력 저장 변수
    private float vertical;     // 세로 입력 저장 변수
    private Vector2 dirVec;     // 현재 플레이어가 보고있는 방향



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
    /// 키보드 키입력 처리 함수
    /// </summary>
    private void GetInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        playerMove.Vertical = vertical;
        playerMove.Horizontal = horizontal;

        // 스페이스키 입력시 플레이어 전방 스캔후 오브젝트가 있다면 오브젝트 정보 저장
        if(Input.GetButtonDown("Jump"))
        {
            playerAction.ScanObject();
        }
    }

    /// <summary>
    /// 현재 플레이어가 보고 있는방향 셋팅
    /// horizontal, vertical 키보드 방향키 하나라도 입력 받을경우에만 보고있는 방향 변경
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
