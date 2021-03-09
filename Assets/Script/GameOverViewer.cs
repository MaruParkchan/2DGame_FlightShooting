using UnityEngine;
using TMPro;

public class GameOverViewer : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        // Stage에 저장된 점수를 불러와서 score 변수에 저장
        int score = PlayerPrefs.GetInt("Score");
        // scoreText UI의 Text 점수 출력
        scoreText.text = "Score\n" + score;
    }
}
