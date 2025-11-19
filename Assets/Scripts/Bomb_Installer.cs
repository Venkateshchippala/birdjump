using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Installer : MonoBehaviour
{
    public static Bomb_Installer instance;
    public List<GameObject> bombs;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance.activateLvl_Number > 1 )
        {
            InvokeRepeating("GetSpawn_Random_Bomn", 2, 3.5f);
        }
    }
    public GameObject GetSpawn_Random_Bomn()
    {
        float xPos = 100;
        float yPos = Random.Range(-250, 250);
        int indexVal = Random.Range(0, bombs.Count);

        GameObject new_Bomb = bombs[indexVal];
        bombs.RemoveAt(indexVal);
        new_Bomb.SetActive(true);
        new_Bomb.transform.localPosition = new Vector2(xPos, yPos);
        return new_Bomb;
    }

    public void Return_to_Pool(GameObject gameObj)
    {
        gameObj.SetActive(false);
        bombs.Add(gameObj);
    }
}
