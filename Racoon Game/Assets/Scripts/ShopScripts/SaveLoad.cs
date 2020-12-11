using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour
{
    public static DataPersistance currentData = new DataPersistance();


    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.persistentDataPath + "/DataPersistance.dat");

        DataPersistance data = currentData;

        bf.Serialize(fs, data);
        fs.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/DataPersistance.dat"))
        {
            try{
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open(Application.persistentDataPath + "/DataPersistance.dat", FileMode.Open);
                DataPersistance data = bf.Deserialize(fs) as DataPersistance;
                fs.Close();

                if (data != null)
                {
                    currentData = data;
                }
                else
                {
                    currentData = new DataPersistance();
                }
            }
            catch(Exception e)
            {
                currentData = new DataPersistance();
            }
        }
        else
        {
            currentData = new DataPersistance();
        }
        currentData = new DataPersistance();
        setData();

    }

    public static void setData()
    {
        currentData.SetData();
        currentData.dollars = 1000;
    }

    void OnApplicationQuit()
    {
        Save();
        Debug.Log("saved");
    }
}