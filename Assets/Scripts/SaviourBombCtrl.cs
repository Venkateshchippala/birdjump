using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaviourBombCtrl : MonoBehaviour
{
    public GameObject player;
    public static SaviourBombCtrl instance;
    public List<GameObject> saviour_Bombs;
    public bool bomb_Ready = true;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        Delay_SaviourBomb();
    }
    public void Delay_SaviourBomb()
    {
        if (GameController.instance.activateLvl_Number > 1 && !GameController.instance.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.K) && bomb_Ready)
            {
                StartCoroutine(Instantiate_SaverBomb());
            }
        }
    }
    IEnumerator Instantiate_SaverBomb()
    {
        bomb_Ready = false;
        GameObject newobj = SaviourBombCtrl.instance.Get_Spawn_SaviourBomb();
        newobj.transform.localPosition = player.transform.localPosition;
        yield return new WaitForSeconds(2);
        bomb_Ready = true;

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
