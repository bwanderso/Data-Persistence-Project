using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string playerName;
    public int highScore;

    public void Awake() {
        if (Instance== null) {
            Instance = this;
            DontDestroyOnLoad( gameObject );
        }
        else {
            Destroy( gameObject );
        }
    }


    [System.Serializable]
    public class HighScore {
        public string playerName;
        public int highScore;
    }

    public void SaveHighScore() {
        HighScore saveData = new HighScore();

        saveData.playerName = this.playerName;
        saveData.highScore = this.highScore;

        string jsonString = JsonUtility.ToJson( saveData );
        File.WriteAllText( Application.persistentDataPath + "/highscore.json", jsonString );
    }

    public void LoadHighScore() {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText( path );
            HighScore saveData = JsonUtility.FromJson<HighScore>(json);

            this.playerName = saveData.playerName;
            this.highScore = saveData.highScore;
        }
    }
}
