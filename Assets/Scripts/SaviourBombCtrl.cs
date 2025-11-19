using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaviourBombCtrl : MonoBehaviour
{
    public static SaviourBombCtrl instance;
    public List<GameObject> saviour_Bombs;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public GameObject Get_Spawn_SaviourBomb()
    {
        int indexVal= Random.Range(0,saviour_Bombs.Count);
        GameObject newObj = saviour_Bombs[indexVal];
        saviour_Bombs.RemoveAt(indexVal);
        newObj.SetActive(true);
        return newObj;
    }

    public void Return_to_Pool(GameObject gameObj)
    {
        gameObj.SetActive(false);
        saviour_Bombs.Add(gameObj);
    }
}
