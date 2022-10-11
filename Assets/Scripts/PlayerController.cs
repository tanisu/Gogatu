using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private bool useAttackAnimation = false;
    
    
    [SerializeField]
    private Collider2D downHitCollision;
    [SerializeField]
    private Collider2D upHitCollision;
    [SerializeField]
    private Collider2D rightHitCollision;
    [SerializeField]
    private Collider2D leftHitCollision;

    [SerializeField]
    private List<GameObject> Harisens;

    private Direction playerDirection;
    private PlayerState playerState;
    private float speed = 2.1f;
    private Animator animator;
    //private Rigidbody2D rb2d;

 



    enum Direction
    {
        D,
        U,
        L,
        R
    }
    enum PlayerState
    {
        STOP,
        IDLE,
        MOVE,
        ATTACK
    }


    
    void Start()
    {
        playerDirection = Direction.D;
        playerState = PlayerState.IDLE;
        animator = GetComponent<Animator>();
        if (!UseAttackAnimation) return;

        downHitCollision.enabled = false;
        leftHitCollision.enabled = false;
        upHitCollision.enabled = false;
        rightHitCollision.enabled = false;
       // rb2d = GetComponent<Rigidbody2D>();

    }

  

    public bool UseAttackAnimation
    {
        get
        {
            return useAttackAnimation;
        }
    }

    void Update()
    {




        if (Input.GetKeyDown(KeyCode.Space) && playerState != PlayerState.MOVE)
        {
            StartCoroutine("Attack", playerDirection);
        }
    }


    public void Move(Vector3 _moveVec)
    {
        if(playerState == PlayerState.ATTACK)
        {
            return;
        }
        transform.Translate(_moveVec * speed * Time.deltaTime);
        if(_moveVec.x < 0)
        {
            if(transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            }
            
            playerDirection = Direction.L;
            animator.SetInteger("WalkParam", (int)playerDirection);
        }
        if (_moveVec.x > 0)
        {
            if(transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
            }
            
            playerDirection = Direction.R;
            animator.SetInteger("WalkParam", (int)playerDirection);
        }
        if (_moveVec.y > 0)
        {
            playerDirection = Direction.U;
            animator.SetInteger("WalkParam", (int)playerDirection);
        }
        if (_moveVec.y  < 0)
        {
            playerDirection = Direction.D;
            animator.SetInteger("WalkParam", (int)playerDirection);
        }
    }

    public void Attack()
    {
        StartCoroutine("_attack", playerDirection);
    }


    private IEnumerator _attack(Direction direction)
    {
        playerState = PlayerState.ATTACK;
        switch (direction)
        {
            case Direction.D:
                if (downHitCollision.enabled == false)
                {
                    downHitCollision.enabled = true;
                    Harisens[(int)direction].SetActive(true);
                }
                break;
            case Direction.L:
                if (leftHitCollision.enabled == false)
                {
                    leftHitCollision.enabled = true;
                    Harisens[(int)direction].SetActive(true);
                }
                break;
            case Direction.U:
                if (upHitCollision.enabled == false)
                {
                    upHitCollision.enabled = true;
                    Harisens[(int)direction].SetActive(true);
                }
                break;
            case Direction.R:
                if (rightHitCollision.enabled == false)
                {
                    rightHitCollision.enabled = true;
                    Harisens[(int)direction].SetActive(true);
                }
                break;
        }
        AudioManager.I.AttackSE();
        yield return new WaitForSeconds(0.2f);

        playerState = PlayerState.IDLE;
        downHitCollision.enabled = false;
        leftHitCollision.enabled = false;
        upHitCollision.enabled = false;
        rightHitCollision.enabled = false;
        Harisens[(int)direction].SetActive(false);
    }

}
