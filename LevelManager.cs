using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour{
    float sceneLoadDelay =  1f;
    ScoreKeeper scoreKeeper;

    void Awake(){ 
        scoreKeeper = FindObjectOfType<ScoreKeeper>(); 
    }
    public void LoadMainMenu(){
        scoreKeeper.loadScores();
        scoreKeeper.resetScore();
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }
    public void LoadGame(){ 
        scoreKeeper.loadScores();
        scoreKeeper.resetScore();
        SceneManager.LoadScene("Main");
        Time.timeScale = 0;
    }
    public void QuitGame(){
        Application.Quit();
    }
    IEnumerator WaitAndLoad(string sceneName, float delay){

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
