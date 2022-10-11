//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AttackAnim : MonoBehaviour
//{
//    [SerializeField]
//    private bool useAttackAnimation = false;
//    [SerializeField]
//    private int animationTotalFlame = 1;
//    [SerializeField]
//    private int animationSpeed = 8;
//    [SerializeField]
//    private Collider2D downHitCollision;
//    [SerializeField]
//    private Collider2D upHitCollision;
//    [SerializeField]
//    private Collider2D rightHitCollision;
//    [SerializeField]
//    private Collider2D leftHitCollision;

//    private int animationFrame = 0;
//    private int animationCount = 0;
//    private bool isEnd = false;
//    private Sprite[] sprites;

//    public bool IsEnd
//    {
//        get
//        {
//            return isEnd;
//        }
//    }

//    public bool UseAttackAnimation
//    {
//        get
//        {
//            return useAttackAnimation;
//        }
//    }

//    void Start()
//    {
//        if (!UseAttackAnimation) return;

//        downHitCollision.enabled = false;
//        leftHitCollision.enabled = false;
//        upHitCollision.enabled = false;
//        rightHitCollision.enabled = false;
//        sprites = Resources.LoadAll<Sprite>(GetComponent<PlayerController>().path + "/attack/");
//    }

//    //public Sprite GetSprite(Direction direction)
//    //{
//    //    if (!UseAttackAnimation) return null;

//    //    if (animationFrame == 0 && animationCount == 0)
//    //    {
//    //        //GameManager.Instance.soundManager.PlayOneShot(SeType.SWISH);
//    //    }

//    //    animationCount++;

//    //    if (animationSpeed <= animationCount)
//    //    {
//    //        animationFrame += 1;
//    //        animationCount = 0;
//    //    }

//    //    if (animationTotalFlame <= animationFrame)
//    //    {
//    //        animationFrame = 0;

//    //        downHitCollision.enabled = false;
//    //        leftHitCollision.enabled = false;
//    //        upHitCollision.enabled = false;
//    //        rightHitCollision.enabled = false;

//    //        return null;
//    //    }

//    //    switch (direction)
//    //    {
//    //        case Direction.D:
//    //            if (downHitCollision.enabled == false) downHitCollision.enabled = true;
//    //            return sprites[0];
//    //        case Direction.L:
//    //            if (leftHitCollision.enabled == false) leftHitCollision.enabled = true;
//    //            return sprites[1];
//    //        case Direction.U:
//    //            if (upHitCollision.enabled == false) upHitCollision.enabled = true;
//    //            return sprites[2];
//    //        case Direction.R:
//    //            if (rightHitCollision.enabled == false) rightHitCollision.enabled = true;
//    //            return sprites[3];
//    //    }

//    //    return null;
//    //}
//}
