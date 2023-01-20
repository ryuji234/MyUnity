using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameoverText;
    private GameObject gamescoreText;
    public GameObject bestScoreText;
    private float gamescore = 0;
    private float Score;    
    private bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        GameObject uiobjs_ = GF.GetRootobj("GALAGAUI");
        gameoverText = uiobjs_.FindChildObj("GameOverText");
        //bestScoreText = uiobjs_.FindChildObj("BestScore");
        gamescoreText = uiobjs_.FindChildObj("GameScore");
        gamescore = 0;
        Score = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            Score = gamescore;
            GF.SetTextMeshPro(gamescoreText, $"Score: {(int)gamescore}");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                
                SceneManager.LoadScene("SampleScene");
            }
            
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
        float bestscore = PlayerPrefs.GetFloat("BestScore");
        //이전까지의 최고 기록보다 현재 생존 시간이 더 긴 경우
        if (Score > bestscore)
        {
            // 플레이어 프리팹스에 베스트 타임을 갱신해서 저장한다.
            bestscore = Score;
            PlayerPrefs.SetFloat("BestScore", bestscore);
            // if: 현재 surviveTime이 bestTime 보다 큰 경우
        }
        // 최고 기록을 텍스트에 갱신한다.
        GF.SetTextMeshPro(bestScoreText, $"Best Score: {(int)bestscore}");
    }       //EndGame()

    public void ScoreAdd()
    {
        if (!isGameover)
        {
            gamescore += 100;
        }
    }
}
