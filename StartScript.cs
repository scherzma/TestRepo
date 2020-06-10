using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ObjectDB DB;
    private static Text text;
    void Start()
    {
        DB = new ObjectDB();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            save();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            getData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            load();
        }
    }

    void save()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " <save ";
        

        if (!DB.Objects.ContainsKey("ob1"))
        {
            DB.Objects.Add("ob1", new SaveThisShit());
            DB.Objects["ob1"].rotX = 1;
            DB.save();
        }
        else
        {
            text.text += "keyExisting";
        }
        
        text.text += " /save> ";
    }

    void getData()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " <rotX_";
        if (DB.Objects.ContainsKey("ob1")) {
            text.text += DB.Objects["ob1"].rotX;
        }
        else
        {
            text.text += "null";
        }
        text.text += " /rotX> ";
    }

    void load()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        text.text += " <load ";
        DB.load();
        text.text += " /load> ";
    }

    void test()
    {
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        Invoke("save", 1F);
        Invoke("load", 3F);
        Invoke("getData", 5F);
        Invoke("save", 7F);
        Invoke("getData", 9F);
        Invoke("test", 11F);
    }
}
