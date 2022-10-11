using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    
    private BossState bossState;
    private float speed = 0.1f;
    private Animator animator;

    
    enum BossState
    {
        STOP,
        START,
        IDLE,
        MOVE,
        BACK,
        RESTART
    }

    private List<Vector3> bossStartPos = new List<Vector3>();
    //private Rigidbody2D rigidbody2;
    private int currentPos;
    private int stopTime;


    void Start()
    {
        currentPos = Random.Range(0,2);

        bossState = BossState.STOP;
        bossStartPos.Add(new Vector3(-145f, 360f, 0f));
        bossStartPos.Add(new Vector3(180f, 360f, 0f));
        
        animator = GetComponent<Animator>();
        BossRandom();
        Invoke("BossStart",4f);
    }

    void BossStart()
    {
        bossState = BossState.START;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.i.gameState == GameState.START)
        {
            if (bossState == BossState.START)
            {
                bossState = BossState.MOVE;
            }
            if (bossState == BossState.MOVE)
            {
                BossWalk(-1);
            }
            if (bossState == BossState.IDLE)
            {
                animator.SetBool("BossStop", true);

                Invoke("BossBack", stopTime);
            }

            if (bossState == BossState.BACK)
            {
                if (transform.localPosition.y > bossStartPos[currentPos].y)
                {
                    animator.SetBool("BossStop", false);
                    bossState = BossState.RESTART;
                }
                BossWalk(1);
                if (GameManager.i.IsStay())
                {
                    GameManager.i.BossLeave();
                }
            }
            if (bossState == BossState.RESTART)
            {
                BossRandom();
                bossState = BossState.MOVE;
            }
        }
        
        
    }

    private void BossRandom()
    {

        stopTime = Random.Range(2, 7);
        currentPos = Random.Range(0, 2);
        speed = Random.Range(0.05f,0.4f);
        transform.localPosition = bossStartPos[currentPos];
    }

    private void BossBack()
    {
        
        bossState = BossState.BACK;
    }

    private void BossWalk(int d)
    {
        transform.position += new Vector3(0f, speed * d, 0f) * Time.deltaTime * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossStop"))
        {
            
            GameManager.i.BossStop();
            bossState = BossState.IDLE;
            
        }
    }
}
