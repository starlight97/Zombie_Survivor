using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectMenuButton : MonoBehaviour
{
    /// <summary>
    /// ���� ��ŸƮ��ư Ŭ���� ĳ���� ����â���� �̵�
    /// </summary>
    public void GameStartClick()
    {
        SceneManager.LoadScene("Stage1");
    }

}