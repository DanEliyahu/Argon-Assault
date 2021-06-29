using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int _score =  0;
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _scoreText.text = _score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.text = _score.ToString();
    }
}