using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    int score;
    public GameObject mainCanvas;
    public GameObject player;
    public GameObject gameOverCanvas;
    public Text scoreText;
    public Text timeDisplay;
    public float totalTime;
    enum GameStates {isPaused,Playing};
    GameStates gameState= GameStates.isPaused;

    static int overallScore;
    static int currentLevel;
    void Start()
    {
        if(currentLevel==0){
            score=0;
        }
        else{ 
            score=overallScore;
        }
        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        if(player==null){
            player=GameObject.FindGameObjectWithTag("Player");
        }
        timeDisplay.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().FreezePlayer(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState){
            case GameStates.isPaused:
                break;
            case GameStates.Playing:
                totalTime-=Time.deltaTime;
                timeDisplay.text=totalTime.ToString("0.0");
                if(totalTime < 0){
                    totalTime=0;
                    mainCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                    player.GetComponent<PlayerController>().FreezePlayer(true);
                }
                break;
        }    
    }
    public void CollectCoin(int value){
        score+=value;
        scoreText.text=score.ToString(); 
    }
    public void BeginGame(){
        timeDisplay.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().FreezePlayer(false);
        gameState=GameStates.Playing;
    }
    private void OnTriggerEnter(Collider other){
        
        if(other.gameObject.tag== "Player" && currentLevel<2){
            currentLevel++;
            overallScore=score;
            SceneManager.LoadScene(currentLevel);
        }
        
        
    }
}
