using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaviourBomb_Move : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.gameOver == false)
        {
            transform.Translate(Vector2.right * 350f * Time.deltaTime);
            if (transform.localPosition.x > -300f)
            {               
                SaviourBombCtrl.instance.Return_to_Pool(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            SaviourBombCtrl.instance.Return_to_Pool(this.gameObject);

        }
    }
}
