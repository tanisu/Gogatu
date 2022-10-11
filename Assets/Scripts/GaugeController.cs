using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GaugeController : MonoBehaviour
{
    [SerializeField]
     Image FillImage;

    void Start()
    {

        FillImage.DOFillAmount(endValue: 1.0f, duration: 3f).Play();
        

    }

}
