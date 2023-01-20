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
        //���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� �� ���
        if (Score > bestscore)
        {
            // �÷��̾� �����ս��� ����Ʈ Ÿ���� �����ؼ� �����Ѵ�.
            bestscore = Score;
            PlayerPrefs.SetFloat("BestScore", bestscore);
            // if: ���� surviveTime�� bestTime ���� ū ���
        }
        // �ְ� ����� �ؽ�Ʈ�� �����Ѵ�.
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
