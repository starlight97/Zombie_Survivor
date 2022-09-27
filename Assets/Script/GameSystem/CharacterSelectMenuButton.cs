using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectMenuButton : MonoBehaviour
{
    /// <summary>
    /// 게임 스타트버튼 클릭시 캐릭터 선택창으로 이동
    /// </summary>
    public void GameStartClick()
    {
        SceneManager.LoadScene("Stage1");
    }

}