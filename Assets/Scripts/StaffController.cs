using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    [SerializeField]
    List<Sprite> Sprites;
    SpriteRenderer sr;
    BoxCollider2D bx2d;
    bool sleeped = false;

    enum StaffState
    {
        SLEEP,
        TIRED,
        AWAKE,
        STATE_MAX
    }
    StaffState staffState;
    float term;
    float seconds;
    void Start()
    {
        
        bx2d = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        int startState = Random.Range(0, (int)StaffState.STATE_MAX);
        term = Random.Range(8f,16f);
        staffState = (StaffState)startState;
        sr.sprite = Sprites[startState];
        CheckSleep();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Harisen"))
        {
            StartCoroutine("AwakeStaff");
        }
    }

    private void FixedUpdate()
    {
        if(GameManager.i.gameState == GameState.START)
        {
            seconds += Time.deltaTime;
            if (seconds >= term && staffState != StaffState.SLEEP)
            {
                seconds = 0;
                int nextState = (int)staffState - 1;
                staffState = (StaffState)nextState;
                sr.sprite = Sprites[nextState];
                CheckSleep();

            }
            if (staffState == StaffState.SLEEP && sleeped)
            {
                GameManager.i.SleepCounter();
                sleeped = false;
            }
        }

    }

    private void CheckSleep()
    {
        if (staffState == StaffState.SLEEP)
        {
            sleeped = true;
        }
    }

    private IEnumerator AwakeStaff()
    {
        sr.sprite = Sprites[3];
        bx2d.enabled = false;
        yield return new WaitForSeconds(0.2f);
        if(staffState == StaffState.SLEEP)
        {
            GameManager.i.NonSleepCounter();
            
            if (GameManager.i.IsStay())
            {
                GameManager.i.DeAngerGauge();
            }
        }
        staffState = StaffState.AWAKE;
        sr.sprite = Sprites[(int)staffState];
        seconds = 0;
        bx2d.enabled = true;
    }




}
