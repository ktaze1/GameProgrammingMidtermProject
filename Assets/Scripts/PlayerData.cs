using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class PlayerData
{
    public int LastScore { get; private set; }

    public float lastYcoor { get; private set; }

    public PlayerData(int LastScore, float lastYcoor)
    {
        this.LastScore = LastScore;
        this.lastYcoor = lastYcoor;
    }

    public PlayerData(int LastScore)
    {
        this.LastScore = LastScore;
    }
    
    public PlayerData(float lastYcoor)
    {
        this.lastYcoor = lastYcoor;
    }

}

public class SaveLoadManager
{

        public static void Save(string path, PlayerData PlayerData)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, PlayerData);
            }
        }
        public static PlayerData Load(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return (PlayerData)formatter.Deserialize(fs);
            }
        }
    }