using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetController : MonoBehaviour
{
    public List<GameObject> obstacles;
    public List<GameObject> instantiateGameObj;
    private float xPos = -600;
    private float yPos = 0;
    private float speed = 300f;
   // [SerializeField] float animationTime = 3f;
    private int currentLevel;   
    // Start is called before the first frame update
    void Start()
    {
        obstacles = GameController.instance.levelCtrl.obstacles;
        currentLevel = GameController.instance.activateLvl_Number;

        //ProcessLevelEntry(currentLevel);
        Obstacles_Instatiate_and_Setposition();
    }
   
    // Update is called once per frame
    void Update()
    {
        if(!GameController.instance.gameOver)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.localPosition.x < -2200f)
        {
            foreach(GameObject obj in instantiateGameObj)
            {
                Destroy(obj);
            }
            instantiateGameObj.Clear();
            transform.localPosition = new Vector2(1600, 0);
            Obstacles_Instatiate_and_Setposition();
        }
    }
   
    public void Obstacles_Instatiate_and_Setposition()
    {
        yPos = -250;
        xPos = -600;

        for (int i = 0; i < 6; i++)
        {
            int indexval = Random.Range(0, obstacles.Count);

            // Instantiate the obstacle prefab
            GameObject newobj = Instantiate(obstacles[indexval], gameObject.transform);

            //RectTransform rt = newobj.GetComponent<RectTransform>();

            float startY = -yPos;
            float endY = yPos;
            float curX = xPos;

            
            newobj.transform.localPosition = new Vector2(curX, startY);
            instantiateGameObj.Add(newobj);
            
            // Prepare next one
            xPos += 300;
            yPos = -yPos;

        }
    }
    

}
