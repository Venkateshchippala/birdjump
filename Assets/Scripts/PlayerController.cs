using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float gravityVal = 6f;
    public bool bomb_Ready = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameController.instance.gameOver == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, gravityVal);
            Debug.Log("I Am Wroking");
        }     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            GameController.instance.gameOver = true;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameController.instance.gameOver = true;
        }
    }
    
}
