using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public GameObject endPanel;
    public Text[] timerTxt;
    public Text bestTimerTxt;
    public Animator dieAni;
    public GameObject boxObj;
    float bestScore = 0;
    bool isEnd = false;

    float nowTime;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("bestScore"))
            bestScore = PlayerPrefs.GetFloat("bestScore");
        nowTime = 0;
        InvokeRepeating("SpawnBox", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd == false)
            nowTime += Time.deltaTime;
        if (timerTxt[0])
            timerTxt[0].text = nowTime.ToString("N2");
        if (timerTxt[1])
            timerTxt[1].text = nowTime.ToString("N2");
    }

    void SpawnBox()
    {
        Instantiate(boxObj);
    }

    public void EndGame()
    {
        Time.timeScale = .2f;

        dieAni.SetBool("isDie", true);
        isEnd = true;
        Invoke("EndGameInvoke", .3f);
        if (nowTime >= bestScore)
        {
            PlayerPrefs.SetFloat("bestScore", nowTime);
            bestScore = nowTime;
        }
        bestTimerTxt.text = bestScore.ToString("N2");
        CancelInvoke("SpawnBox");

    }

    public void EndGameInvoke()
    {
        Time.timeScale = 0;
        endPanel.SetActive(true);
    }
    public GameManager GetGameManager()
    {
        return Instance;
    }

    public void OnClickButtonReGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
