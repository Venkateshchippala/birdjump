using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : MonoBehaviour
{
    private float speed = 250f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.instance.gameOver)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.localPosition.x < -1050)
        {
            Bomb_Installer.instance.Return_to_Pool(this.gameObject);
        }
    }
}
