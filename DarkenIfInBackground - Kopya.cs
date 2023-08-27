using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkenIfInBackground : MonoBehaviour
{
    [Tooltip("Objenin arkaplan objesi olup olad���n� belirler. E�er true ise obje, karakter veya di�er objelerle etkile�ime girmez, temas edemez. False ise obje, karakter veya di�er objeler ile etkile�ime girebilir, temas edebilir ve Trigger'� alg�layabilir. ")]
    public bool IsInBackground;
    public Color DarkenedColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsInBackground == true)
        {
            gameObject.GetComponent<SpriteRenderer>().color = DarkenedColor;

            if (gameObject.GetComponent<BoxCollider2D>())
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            if (gameObject.GetComponent<PolygonCollider2D>())
            {
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
            }

            if (gameObject.GetComponent<Rigidbody2D>())
            {
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        else if(IsInBackground == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            if (gameObject.GetComponent<BoxCollider2D>())
            {
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            if (gameObject.GetComponent<PolygonCollider2D>())
            {
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            }

            if (gameObject.GetComponent<Rigidbody2D>())
            {
                gameObject.GetComponent<Rigidbody2D>().simulated = true;
            }
        }
    }
}
