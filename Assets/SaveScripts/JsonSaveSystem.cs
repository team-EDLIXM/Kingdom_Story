using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JsonSaveSystem
{ 
    private readonly string _filePath;

    public JsonSaveSystem()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
    }

    public void Save(SaveData data)
    {
        MonoBehaviour.print("saved");
        
        var json = JsonUtility.ToJson(data);
        using var writer = new StreamWriter(_filePath,false);
        writer.WriteLine(json);
    }

    public void SaveRestart(SaveData data)
    {
        Save(data);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public SaveData Load()
    {
        MonoBehaviour.print("loaded");

        string json = "";
        if (File.Exists(_filePath))
            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }

        if (string.IsNullOrEmpty(json))
            return new SaveData();

        return JsonUtility.FromJson<SaveData>(json);
    }
/*
    public SaveData LoadRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        return Load();
    }
*/
}
