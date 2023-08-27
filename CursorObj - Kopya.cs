using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorObj : MonoBehaviour
{
    public Vector2 CursorPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = CursorPos;
    }
}
