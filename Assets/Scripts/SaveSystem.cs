
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem
{
    public static void SavePlayer()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" +GlobleData.PlayerID+ ".player";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);
        stream.Close();

    }
    public static PlayerData LoadPlayer()
    {


        string path = Application.persistentDataPath + "/" + GlobleData.PlayerID + ".player";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return (PlayerData)data;
        }
        else
        {
            //Debug.LogError("Save file not found in" + path);
            
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("");
            }
            return null;
        }



    }


}
