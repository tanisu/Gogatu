using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    [SerializeField]
    Sprite[] WorstImages;
    [SerializeField]
    Sprite[] BadImages;
    [SerializeField]
    Sprite[] UsuallyImages;
    [SerializeField]
    Sprite[] GoodImages;
    [SerializeField]
    Sprite[] BestImages;
    [SerializeField]
    Image MessageImage;
    [SerializeField]
    Transform PressStart;

    private int max;
    private int idx;
    private void Awake()
    {
        AudioManager.GetI();
    }

    void Start()
    {
        int result = GameManager.angerGauge;
        
        if(result >= 20)
        {
            max = WorstImages.Length;
            idx = Random.Range(0, max);
            MessageImage.sprite = WorstImages[idx];
            //�ň��̌���
        }
        else if(result >= 15)
        {
            max = BadImages.Length;
            idx = Random.Range(0, max);
            MessageImage.sprite = BadImages[idx];
            //�s�@��
        }
        else if(result >= 10)
        {
            max = UsuallyImages.Length;
            idx = Random.Range(0, max);
            MessageImage.sprite = UsuallyImages[idx];
            //����
        }
        else if(result >= 5)
        {
            //��@��
            max = GoodImages.Length;
            idx = Random.Range(0, max);
            MessageImage.sprite = GoodImages[idx];
        }
        else
        {
            max = BestImages.Length;
            idx = Random.Range(0, max);
            MessageImage.sprite = BestImages[idx];
            //����
        }

    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.I.StopBGM_2();
            SceneManager.LoadScene("Title");
        }
    }

 
}
