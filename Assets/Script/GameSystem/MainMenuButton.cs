using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{


    /// <summary>
    /// ���� ��ŸƮ��ư Ŭ���� ĳ���� ����â���� �̵�
    /// </summary>
    public void GameStartClick()
    {
        SceneManager.LoadScene("CharacterSelectMenu");
    }

    /// <summary>
    /// ���ù�ư Ŭ���� �۵� �Լ�
    /// </summary>
    public void SettingClick()
    {

    }

    /// <summary>
    /// �����ư Ŭ���� �۵��Լ�
    /// </summary>
    public void QuitClick()
    {
        Application.Quit();
    }
}
