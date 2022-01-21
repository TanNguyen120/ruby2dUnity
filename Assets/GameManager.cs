using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;

    bool isOpenMenu = false;


    public static GameManager instance = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void saveGame(GameObject player)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.hd");
        FileStream saveFile = File.Create(path);
        RubyController ruby = player.GetComponent<RubyController>();
        SaveGameData saveData = new SaveGameData((int)ruby.health, ruby.transform.position);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(saveFile, saveData);
        saveFile.Close();
        Debug.Log("Save at:" + path);
    }

    public void loadGame(GameObject player)
    {
        string path = Path.Combine(Application.persistentDataPath, "player.hd");
        if (File.Exists(path))
        {
            FileStream saveFile = File.Open(path, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            SaveGameData saveData = (SaveGameData)formatter.Deserialize(saveFile);
            RubyController ruby = player.GetComponent<RubyController>();
            ruby.health = saveData.health;
            ruby.transform.position = new Vector2(saveData.postion[0], saveData.postion[1]);
            Debug.Log(" postion save at: " + saveData.postion[0] + saveData.postion[1]);
            Debug.Log("load save" + path);
        }
    }

    public void openMenu()
    {
        if (isOpenMenu)
        {
            menu.SetActive(false);
            isOpenMenu = false;
        }
        else
        {
            menu.SetActive(true);
            isOpenMenu = true;
        }
    }
}
