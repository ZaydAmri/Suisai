using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class JsonDataScript : MonoBehaviour
{

    string path;
    string jsonString;
    public List<Levels> levels = new List<Levels>();


    [System.Serializable]
    public class Levels
    {
        public int id;
        public string sceneName;
        public bool unlocked;
        public string returnToLevel;

        public Levels()
        {

        }
        public Levels(int _id, string _sceneName, bool _unlocked, string _returnToLevel)
        {
            id = _id;
            sceneName = _sceneName;
            unlocked = _unlocked;
            returnToLevel = _returnToLevel;

        }

    }

    void Start()
    {
        path = Application.streamingAssetsPath + "/LevelsData.json";
        jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);
        
        levels = JsonHelper.FromJson<Levels>(jsonString);
        Debug.Log(levels[0].sceneName);
        Debug.Log(levels[1].sceneName);
        Debug.Log(levels[2].sceneName);
        Debug.Log(levels[3].sceneName);
        Debug.Log(levels[4].sceneName);

    }




    

    public bool getLevelInformationUnlocked()
    {
        return true;
    }

    [System.Serializable]
    public static class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(List<T> array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(List<T> array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public List<T> Items;
        }
    }

    //-------------------
}
