using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public string playerName;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
    }

    public void ReadStringInput(string name)
    {
        playerName = name;
    }

    [System.Serializable]
    
    class SaveData
    {
        public string playerName;
    }
    public void SaveName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

#if UNITY_EDITOR
        Debug.Log("Name Saved!");
#endif
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
#if UNITY_EDITOR
            Debug.Log("Name Loaded!");
#endif
        }
    }
}
