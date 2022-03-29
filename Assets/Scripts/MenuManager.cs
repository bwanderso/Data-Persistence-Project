using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{

    public Text bestScoreText;
    public InputField playerNameTextField;

    public void Start() {
        ScoreManager.Instance.LoadHighScore();
        if (ScoreManager.Instance.highScore  > 0 ) {
            bestScoreText.text = "Best Score : " + ScoreManager.Instance.playerName + " : " + ScoreManager.Instance.highScore;
            playerNameTextField.text = ScoreManager.Instance.playerName;
        } else {
            bestScoreText.text = "Best Score : 0 : 0";
        }

    }

    public void UpdatePlayerName() {
        ScoreManager.Instance.playerName = playerNameTextField.text;
    }

    public void StartGame() {
        SceneManager.LoadScene( 1 );
    }

    public void ExitGame() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
