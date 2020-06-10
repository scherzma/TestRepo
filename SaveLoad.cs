using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

#if !UNITY_EDITOR && UNITY_WSA
    using Windows.Storage;
    using System.Threading.Tasks;
#endif

public class SaveLoad : MonoBehaviour
{
#if !UNITY_EDITOR && UNITY_WSA
        static StorageFolder pathARP;
        static StorageFolder pathObj;
    #endif
    private static Text text;

    void Start()
    {
    }
        
    public SaveLoad()
    {

    }
        
        
    public static async Task Save<T>(T objectToSave)
    {
        
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " saveLoad_save ";

#if !UNITY_EDITOR && UNITY_WSA
            pathARP = await KnownFolders.Objects3D.CreateFolderAsync("AR_PROJEKT", CreationCollisionOption.OpenIfExists);
            text.text += pathARP.Path;
            StorageFile jsonFile = await pathARP.CreateFileAsync("config.json", CreationCollisionOption.OpenIfExists);
            text.text += " JSON: "+JsonConvert.SerializeObject(objectToSave)+"    ";
            await FileIO.WriteTextAsync(jsonFile, JsonConvert.SerializeObject(objectToSave));
#endif
    }


    public static async Task<T> Load<T>()
    {

#if !UNITY_EDITOR && UNITY_WSA 

        StorageFile jsonFile = await KnownFolders.Objects3D.CreateFileAsync("AR_PROJEKT\\config.json", CreationCollisionOption.OpenIfExists);
        T ret = JsonConvert.DeserializeObject<T>(await FileIO.ReadTextAsync(jsonFile));
            
        if (ret == null)
        {
            ret = default(T);
        }

        return ret;

#else
        return default(T);
#endif
    }
















    /*
    static async Task<int> GetLeisureHours()
    {
        // Task.FromResult is a placeholder for actual work that returns a string.  
        var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());
        // The method then can process the result in some way.  
        int leisureHours;
        if (today.First() == 'S')
            leisureHours = 16;
        else
            leisureHours = 5;
        return 1;
    }
    */
}
