using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class PersistentManager : MonoBehaviour
{

    public static PersistentManager dataStore;

    public int currentLevelID;

    public int gemCollected;
    public int highestLevelCompleted;

    void Awake()
    {
        if (dataStore == null)
        {
            DontDestroyOnLoad(gameObject);
            dataStore = this;
            //Load();
        }
        else if (dataStore != this)
        {
            Destroy(gameObject);
        }
    }

    public void endGameWithWin()
    {
        Debug.Log("Game over -Win!");
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Fase1");
    }

    public void endGameWithLoss()
    {
        Debug.Log("Game over - Loss!");
        Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Fase1");
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameData.dat");
        GameData data = new GameData();
        data.gemsCollectedTotal = gemCollected;
        data.highestLevel = highestLevelCompleted;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();

            gemCollected = data.gemsCollectedTotal;
            highestLevelCompleted = data.highestLevel;
        }
    }

    [Serializable]
    class GameData
    {
        public int gemsCollectedTotal;
        public int highestLevel;
    }

}
