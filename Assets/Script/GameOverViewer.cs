using UnityEngine;
using TMPro;

public class GameOverViewer : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        // Stage�� ����� ������ �ҷ��ͼ� score ������ ����
        int score = PlayerPrefs.GetInt("Score");
        // scoreText UI�� Text ���� ���
        scoreText.text = "Score\n" + score;
    }
}
