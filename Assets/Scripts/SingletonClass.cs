using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SingletonClass : MonoBehaviour
{

    // Start() and Update() methods deleted - we don't need them right now
    public string playerName;
    public string highScorePlayer;
    public int currentHighScore;

    public static SingletonClass Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighscore(int highScore)
    {
        if(highScore > currentHighScore)
        {
            currentHighScore = highScore;
            highScorePlayer = playerName;
            SaveHighScore newHighscore = new SaveHighScore();
            newHighscore.name = playerName;
            newHighscore.highScore = highScore;

            string highScoreJson = JsonUtility.ToJson(newHighscore);
            File.WriteAllText(Application.persistentDataPath + "/highscore.json", highScoreJson);
        }
        
    }

    public void LoadHighscore()
    {
        string filePath = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveHighScore hsObject = JsonUtility.FromJson<SaveHighScore>(json);
            highScorePlayer = hsObject.name;
            currentHighScore = hsObject.highScore;
        }
    }



    [System.Serializable]
    public class SaveHighScore
    {
        public string name;
        public int highScore;
    }
}

