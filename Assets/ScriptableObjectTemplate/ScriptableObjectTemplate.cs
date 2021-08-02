using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectTemplate : MonoBehaviour
{
    [SerializeField] private MonsterDataObject moster1;
    [SerializeField] private MonsterDataObject moster2;

    private void Awake()
    {
        
        Debug.Log(moster1.monsterData.ToString());
        Debug.Log(moster2.monsterData.ToString());
    }
}
