using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    static private Text _uiText;
    static private int _score = 0;

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void Awake() {
        _uiText = GetComponent<Text>();
        if (PlayerPrefs.HasKey("HighScore")) {
            Score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", Score);
    }

    static public int Score {
        get { return _score; }
        private set {
            _score = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_uiText != null) {
                _uiText.text = "High Score: " + value.ToString("#,0");
            }
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) {
        if (scoreToTry <= Score) return;
        Score = scoreToTry;
    }

void OnDrawGizmos() {
    if (resetHighScoreNow) {
        resetHighScoreNow = false;
        PlayerPrefs.SetInt("HighScore", 0);
        if (_uiText != null) {
            _uiText.text = "High Score: 1,000";
        }
        Debug.LogWarning("PlayerPrefs HighScore reset to 0");
        }
    }
}