using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI classes like Text.

public class ScoreCounter : MonoBehaviour {
    [Header("Dynamic")]
    public int score = 0;

    private Text uiText;

    void Start() {
    uiText = GetComponent<Text>();
    if (uiText == null) Debug.LogError("ScoreCounter: No Text component found!", this);
}

void Update() {
    if (uiText != null) uiText.text = score.ToString("#,0");
}
}