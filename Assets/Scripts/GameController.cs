using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameController : MonoBehaviour
{
    public static GameController instance; 
    public LevelCtrl[] allLevels;
    public LevelCtrl levelCtrl;
    public int activateLvl_Number = 0;
    
    public bool gameOver = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        Activated_Level(activateLvl_Number);
    }
    public void Activated_Level(int lvl)
    {
        levelCtrl = allLevels[lvl];
        levelCtrl.gameObject.SetActive(true);
    }
}
