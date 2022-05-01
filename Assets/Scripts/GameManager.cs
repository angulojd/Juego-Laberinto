using UnityEngine;
using System.Collections;
using System.Collections.Generic;       
using UnityEngine.UI;                   


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              

    public float levelStartDelay = 2f;                     
    public float turnDelay = 0.1f;                         
    public int playerFoodPoints = 100;                      

    [HideInInspector]
    public bool playersTurn = true;                         
    [HideInInspector]
    public bool doingSetup = true;                          

    private Text levelText;                                 
    private GameObject levelImage;                          
    private BoardManager boardScript;                       
    private int level = 1;                                  
    private List<Enemy> enemies;                            
    private bool enemiesMoving;                             

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
        enemies = new List<Enemy>();
        boardScript = GetComponent<BoardManager>();
        InitGame();
    }

    void OnLevelWasLoaded(int index)
    {
        level++;
        if(level == 6)
        {
            Winner();
        }
        else
        {
            InitGame();
        }
    }

    public void Winner()
    {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Despues de " + level + " días, sobreviviste.";
        levelImage.SetActive(true);
        enabled = false;
    }

    void InitGame()
    {
        doingSetup = true;
        levelImage = GameObject.Find("LevelImage");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Día " + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
        enemies.Clear();
        boardScript.SetupScene(level);
    }


    void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetup = false;
    }

    void Update()
    {
        if (playersTurn || enemiesMoving || doingSetup)
            return;
        StartCoroutine(MoveEnemies());
    }

    public void AddEnemyToList(Enemy script)
    {
        enemies.Add(script);
    }


    public void GameOver()
    {
        levelText.text = "Despues de " + level + " días, moriste de hambre.";
        levelImage.SetActive(true);
        enabled = false;
    }

    IEnumerator MoveEnemies()
    {
        enemiesMoving = true;
        yield return new WaitForSeconds(turnDelay);

        if (enemies.Count == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].MoveEnemy();
            yield return new WaitForSeconds(enemies[i].moveTime);
        }

        playersTurn = true;
        enemiesMoving = false;
    }
}
