using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class GameState
{
    public MapData mapData;
    public ResourceData resourceData;

    public static bool Save(string saveName, object saveData)
    {
        BinaryFormatter formatter = GetBinaryFormatter();

        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        string savePath = Application.persistentDataPath + "/saves" + "/" + saveName + ".save";

        FileStream file = File.Create(savePath);

        formatter.Serialize(file, saveData);

        file.Close();

        return true;
    }

    public static object Load(string saveName)
    {
        string savePath = Application.persistentDataPath + "/saves" + "/" + saveName + ".save";

        if (!File.Exists(savePath))
        {
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(savePath, FileMode.Open);

        try
        {
            object saveData = formatter.Deserialize(file);
            return saveData;
        } catch
        {
            Debug.LogErrorFormat("Failed to load file at {0}", savePath);
        } finally
        {
            file.Close();
        }

        return null;
    }

    private static BinaryFormatter GetBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
}
