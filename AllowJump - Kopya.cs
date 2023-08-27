using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowJump : MonoBehaviour
{
    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.transform.parent.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "zemin")
        {
            characterController.IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "zemin")
        {
            characterController.IsGrounded = false;
        }
    }
}
