using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager i;
    private bool bossStop;
    private bool bossStay;
    private int sleepCounter;
    public static int angerGauge { get; private set; } = 0;


    
    private float seconds = 0f;
    
    private float startTime = 1.0f;

    [SerializeField]
    private float maxAngerGauge = 20f;
    [SerializeField]
    private float limitTime = 60f;
    
    [SerializeField]
    Image FillAnger;
    [SerializeField]
    Image TimerImage;
    [SerializeField]
    Image StartImage;
    [SerializeField]
    PlayerController player;

    public GameState gameState;

    private void Awake()
    {
        i = this;
        AudioManager.GetI();
    }

    void Start()
    {
        angerGauge = 0;
        StartCoroutine("ReadyGame");

    }

    private IEnumerator ReadyGame()
    {
        
        yield return StartImage.transform.DOLocalMoveX(0, 1f).SetEase(Ease.InCubic).SetLink(StartImage.gameObject).OnComplete(()=> {
            AudioManager.I.FlashSE();
            StartImage.transform.DOLocalMoveX(-900, 1f).SetEase(Ease.InCubic);
        }).WaitForCompletion();
        AudioManager.I.MainBGM();
        gameState = GameState.START;
    }

    
    void Update()
    {
        float h = (int)(Input.GetAxis("Horizontal"));
        float v = (int)(Input.GetAxis("Vertical"));
        if (gameState == GameState.START)
        {

            if (bossStop)
            {
                //Q‚Ä‚éŽÐˆõ‚Ì”‚ð”‚¦‚é
                bossStop = false;
                CountStaff();
            }
            if (angerGauge >= maxAngerGauge)
            {
                GameOver();
            }
            UpdateTimer();
            UpdateAnger();

            player.Move(new Vector3(h, v, 0));

        }
    }

    private void GameOver()
    {
        gameState = GameState.GAMEOVER;

        StartCoroutine("GameOverScene");
    }

    private IEnumerator GameOverScene()
    {
        StartImage.GetComponent<ImageController>().ChangeImage();
        yield return DOTween.Sequence()
            .Append(StartImage.transform.DOLocalMoveX(0, 1f).SetEase(Ease.InCubic))
            .AppendInterval(0.1f)
            .Append(StartImage.transform.DOLocalMoveX(900, 1f).SetEase(Ease.InCubic))
            .WaitForCompletion();

        SceneManager.LoadScene("GameOver");
    }

    private void UpdateTimer()
    {
        seconds += Time.deltaTime;
        
        float timerfloat = seconds / limitTime;
        
        if (startTime > 0)
        {
            startTime = 1f - timerfloat;
            
            
            TimerImage.DOFillAmount(startTime, 0.1f).SetEase(Ease.Linear).SetLink(TimerImage.gameObject);
        }
        if(seconds >= limitTime)
        {
            GameOver();
        }

    }

    private void UpdateAnger()
    {
        
        float angerFloat = angerGauge / maxAngerGauge;
        FillAnger.DOFillAmount(angerFloat, 0.1f).SetEase(Ease.InSine).SetLink(FillAnger.gameObject);
        
    }

    private void CountStaff()
    {
        if(sleepCounter > 0)
        {
            AudioManager.I.AngerSE();
            angerGauge += sleepCounter;
        }
        else
        {
            angerGauge = 0;
        }
    }

    public void DeAngerGauge()
    {
        if (angerGauge > 0)
        {
            angerGauge--;
            UpdateAnger();
        }
        
    }

    public void SleepCounter()
    {
        sleepCounter++;
    }

    public void NonSleepCounter()
    {
        if(sleepCounter > 0)
        {
            sleepCounter--;
        }
        
    }

    public void BossStop()
    {
        bossStop = true;
        bossStay = true;
    }
    public void BossLeave()
    {
        bossStay = false;
    }

    public bool IsStay()
    {
        return bossStay;
    }
}
