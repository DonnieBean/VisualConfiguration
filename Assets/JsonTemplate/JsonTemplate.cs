using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonTemplate : MonoBehaviour
{
    [SerializeField]private string filePath= "MonsterDatas.json";

    private List<MonsterData> monsterDatas;
    
    private void Awake()
    {
        string path = Path.Combine(Application.streamingAssetsPath, filePath);
        monsterDatas = JsonConvert.DeserializeObject<List<MonsterData>>(File.ReadAllText(path));

        foreach (var item in monsterDatas)
        {
            Debug.Log(item.ToString());
        }
    }
}
