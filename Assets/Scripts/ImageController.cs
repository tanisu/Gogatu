using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Sprite EndImage;
    public void ChangeImage()
    {
        GetComponent<Image>().sprite = EndImage;
    }
}
