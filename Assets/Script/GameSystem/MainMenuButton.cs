using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{


    /// <summary>
    /// 게임 스타트버튼 클릭시 캐릭터 선택창으로 이동
    /// </summary>
    public void GameStartClick()
    {
        SceneManager.LoadScene("CharacterSelectMenu");
    }

    /// <summary>
    /// 셋팅버튼 클릭시 작동 함수
    /// </summary>
    public void SettingClick()
    {

    }

    /// <summary>
    /// 종료버튼 클릭시 작동함수
    /// </summary>
    public void QuitClick()
    {
        Application.Quit();
    }
}
