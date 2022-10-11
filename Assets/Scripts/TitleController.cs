using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    Image Title_1;
    [SerializeField]
    Image Title_2;
    private void Awake()
    {
        
        AudioManager.GetI();
    }
    void Start()
    {

        Sequence sq = DOTween.Sequence()
            .OnStart(() =>
            {
                
                Title_1.transform.DOLocalMoveX(endValue: -180f, duration: 0.5f)
                    .SetEase(Ease.InCubic)
                    .SetLink(Title_1.gameObject).OnComplete(()=> { AudioManager.I.FlashSE(); });


            }).Append(
                Title_2.transform.DOLocalMoveX(endValue: 200f, duration: 0.5f)
               .SetEase(Ease.InCubic)
               .SetLink(Title_1.gameObject)
            )
            .AppendCallback(()=> {
                
                transform.DOLocalMoveY(endValue: -2f, duration: 0.5f)
                .SetEase(Ease.InCubic)
                .SetLink(gameObject).OnComplete(()=> { AudioManager.I.TitleBGM();  });
                
            });
        sq.Play();
        
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
        
            SceneManager.LoadScene("GameMain");
            AudioManager.I.StopBGM();
        }
    }

  
}
