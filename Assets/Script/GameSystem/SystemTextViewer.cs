using UnityEngine;
using TMPro;

public class SystemTextViewer : MonoBehaviour
{
    private TextMeshProUGUI textTimeLimit;   // Text - TextMeshPro UI [���� �ð�]

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        textTimeLimit.text = "Time Limit : " + gameManager.TimeLimit;
    }

    private void Setup()
    {
        textTimeLimit = transform.Find("TextTimeLimit").GetComponent<TextMeshProUGUI>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
