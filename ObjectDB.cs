using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;
//using Newtonsoft.Json;

public class ObjectDB : MonoBehaviour
{

    public Dictionary<string, SaveThisShit> Objects;
    private static Text text;
    public void save()
    {
        if (Objects != null)
        {
            saveHelper();
        }
        else
        {
            load();
            saveHelper();
        }
        
    }

    public async void saveHelper()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " savedDB ";
        await SaveLoad.Save(Objects);
    }

    public void load()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " loadInObjectDB ";

        Task<Dictionary<string, SaveThisShit>> task = Task.Run<Dictionary<string, SaveThisShit>>(async () => await SaveLoad.Load<Dictionary<string, SaveThisShit>>());
        Objects = task.Result;
        

        if (Objects == null)
        {
            text.text += " objectsNull ";
            Objects = new Dictionary<string, SaveThisShit>();
        }
    }

    public ObjectDB()
    {
        Objects = new Dictionary<string, SaveThisShit>();
    }

}
