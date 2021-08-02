using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class DataEditor : EditorWindow
{
    private static List<MonsterData> monsterDatas;

    private static MonsterData crtMonsterData;

    [MenuItem("Tools/数据配置", false)]
    private static void ShowWindow()
    {
        monsterDatas = null;
        string path = Path.Combine(Application.streamingAssetsPath, "MonsterDatas.json");
        if (File.Exists(path))
        {
            string txt = File.ReadAllText(path);
            try
            {
                monsterDatas = JsonConvert.DeserializeObject<List<MonsterData>>(txt);
            }
            catch (System.Exception)
            {
                Debug.LogWarning("反序列化失败");
            }
        }
        if (monsterDatas == null)
        {
            monsterDatas = new List<MonsterData>();
        }

        GetWindow(typeof(DataEditor));
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        DrawLeft();
        DrawRight();
        EditorGUILayout.EndHorizontal();

        DrawBottom();
    }

    private void DrawLeft()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("当前对象", GUILayout.Width(250));
        if (crtMonsterData==null)
        {
            EditorGUILayout.LabelField("当前未选择对象",GUILayout.Width(100));
        }
        else
        {
            GUILayout.Label("Name", GUILayout.Width(50));
            crtMonsterData.Name = EditorGUILayout.TextField(crtMonsterData.Name, GUILayout.Width(200));
            GUILayout.Label("Hp", GUILayout.Width(50));
            crtMonsterData.Hp = float.Parse( EditorGUILayout.TextField(crtMonsterData.Hp.ToString(), GUILayout.Width(200)));
            GUILayout.Label("Atk", GUILayout.Width(50));
            crtMonsterData.Atk = float.Parse(EditorGUILayout.TextField(crtMonsterData.Atk.ToString(), GUILayout.Width(200)));
            GUILayout.Label("Def", GUILayout.Width(50));
            crtMonsterData.Def = float.Parse(EditorGUILayout.TextField(crtMonsterData.Def.ToString(), GUILayout.Width(200)));
        }
        if (GUILayout.Button("删除数据", GUILayout.Width(100)))
        {
            monsterDatas.Remove(crtMonsterData);
            crtMonsterData = null;
        }

        EditorGUILayout.EndVertical();
    }

    private void DrawRight()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("对象列表", GUILayout.Width(350));
        foreach (var item in monsterDatas)
        {
            if (GUILayout.Button(item.Name, GUILayout.Width(300)))
            {
                crtMonsterData = item;
            }
        }
        if (GUILayout.Button("新增数据", GUILayout.Width(100)))
        {
            monsterDatas.Add(new MonsterData() { Name="新敌人"});
        }
        EditorGUILayout.EndVertical();
    }

    private void DrawBottom()
    {
        if (GUILayout.Button("保存数据"))
        {
            string path = Path.Combine(Application.streamingAssetsPath, "MonsterDatas.json");
            FileStream fs=new FileStream(path,FileMode.OpenOrCreate);
            byte[] b= Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(monsterDatas));
            fs.Write(b,0,b.Length);
            fs.Close();
        }
    }
}
