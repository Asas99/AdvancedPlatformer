using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimPlayer : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Sprite[] sprites;
    public float SpriteChangeTime, currentTime;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

            SpriteRenderer.sprite = sprites[i];

            if (currentTime < 0)
            {
                //print("" + i +" " + currentTime);
                currentTime = SpriteChangeTime;
                i++;
            }

            if (i >= sprites.Length)
            {
                i = 0;
            }
    }
}
