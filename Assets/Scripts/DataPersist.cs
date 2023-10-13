using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersist : MonoBehaviour
{
    public static DataPersist Instance { get; private set; }

    public string PlayerName = "";
    public string PlayerHighScoreName = "";
    public int Score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        Load();
    }
    

    [System.Serializable]
    class PlayerData
    {
        public string PlayerName;
        public string PlayerHighScoreName;
        public int Score;
    }

    public void Save()
    {
        PlayerData data = new PlayerData();
        data.PlayerName = PlayerName;
        data.PlayerHighScoreName = PlayerHighScoreName;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if(!File.Exists(path)) return;
        string json = File.ReadAllText(path);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        PlayerName = data.PlayerName;
        PlayerHighScoreName = data.PlayerHighScoreName;
        Score = data.Score;
    }
}
