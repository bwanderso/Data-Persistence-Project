using System.Collections;
using System.Collections.Generic;
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
}
