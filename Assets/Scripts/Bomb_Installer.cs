using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Installer : MonoBehaviour
{
    public List<GameObject> bomb;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance.activateLvl_Number > 1 )
        {
            InvokeRepeating("Bomb_Instantiation", 2, 3.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bomb_Instantiation()
    {
        
        int indexval = Random.Range(0, bomb.Count);
        float xPos = 600;
        float yPos = Random.Range(-250, 250);
        if (!GameController.instance.gameOver)
        {
            GameObject newobj = Instantiate(bomb[indexval], gameObject.transform);
            newobj.transform.localPosition = new Vector2(xPos, yPos);
        }
        
        
        /*RectTransform rt = newobj.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(xPos, yPos);*/
    }
}
