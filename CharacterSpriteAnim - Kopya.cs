using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteAnim : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite[] WalkingSprites;
    public float WalkingSpriteChangeTime, currentTime1; 
    public Sprite[] IdleSprites;
    public float IdleSpriteChangeTime, currentTime2;
    public int i,i2;
    public Vector3 CharacterPos;
    public float Offset;
    public bool TurnedLeft, TurnedRight;
    public bool CanWalk = true;
    // Start is called before the first frame update
    void Start()
    {
        TurnedRight = true;
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
        CharacterPos = gameObject.transform.position;
        currentTime1 -= Time.deltaTime;

        SpriteRenderer.sprite = WalkingSprites[i];

        if (CanWalk == true)
            {
        if (currentTime1 < 0)
        {
            //print("" + i +" " + currentTime);
            currentTime1 = WalkingSpriteChangeTime;
            i++;
        
            }
        }
        else if(CanWalk == false)
        {
            i = 0;
        }

        if (i >= WalkingSprites.Length)
        {
            i = 0;
        }
        }


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            CharacterPos = gameObject.transform.position;
            currentTime1 -= Time.deltaTime;

            SpriteRenderer.sprite = WalkingSprites[0];
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (TurnedRight == true)
            {
            gameObject.transform.position = new Vector3(CharacterPos.x + Offset, CharacterPos.y, CharacterPos.z);
                TurnedRight = false;
                TurnedLeft = true;
            }
            gameObject.transform.localScale = new Vector3(Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y,gameObject.transform.localScale.z);

        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (TurnedLeft == true)
            {
                gameObject.transform.position = new Vector3(CharacterPos.x - Offset, CharacterPos.y, CharacterPos.z);
                TurnedLeft = false;
                TurnedRight = true;
            }
            gameObject.transform.localScale = new Vector3(-Mathf.Abs(gameObject.transform.localScale.x), gameObject.transform.localScale.y,gameObject.transform.localScale.z);

        }

        if (!Input.anyKey)
        {
            CharacterPos = gameObject.transform.position;
            currentTime2 -= Time.deltaTime;

            SpriteRenderer.sprite = IdleSprites[i2];

            if (currentTime2 < 0)
            {
                //print("" + i +" " + currentTime);
                currentTime2 = IdleSpriteChangeTime;
                i2++;
            }

            if (i2 >= IdleSprites.Length)
            {
                i2 = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            CanWalk = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            CanWalk = false;
        }
    }
}

