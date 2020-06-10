using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
#if !UNITY_EDITOR && UNITY_WSA
using Windows.Storage;
#endif
using System.Threading.Tasks;
using System.Threading;


public class file : MonoBehaviour {

    
    // Use this for initialization

    [SerializeField]public Vector3 RotateAmount;
#if !UNITY_EDITOR && UNITY_WSA
    static StorageFolder storageFolder;
    static StorageFolder objekteFolder;
    static StorageFolder testFolder;
#endif
    private static Text text;
    
    void Start () {



        text = GameObject.Find("Canvas/Text").GetComponent<Text>();

        text.text = "";
        RotateAmount.x = 10;
        Debug.Log("hi");




    }

    public static async void CreateFile()
    {
#if !UNITY_EDITOR && UNITY_WSA
        text.text += "hi";
        storageFolder = KnownFolders.Objects3D;
        storageFolder = await storageFolder.CreateFolderAsync("AR_PROJEKT", CreationCollisionOption.OpenIfExists);    
#endif

    }


    public async Task<string> ReadFile1()
    {
#if !UNITY_EDITOR && UNITY_WSA
        var textFileFromExternalPath = await StorageFile.GetFileFromPathAsync("C:\\Users\\Shz\\3D Objects\\AR_PROJEKT\\test.txt");

        var fileContent = await FileIO.ReadTextAsync(textFileFromExternalPath);

        return fileContent;
#else
        return "";
#endif
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateFile();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
#if !UNITY_EDITOR && UNITY_WSA || true
            //var task = Task.Run(async () => await ReadFile1());
            //var result = task.RunSynchronously();
#endif
            Task<string> task = Task.Run<string>(async () => await ReadFile1());
            text.text += task.Result;

        }
    }
    
}
