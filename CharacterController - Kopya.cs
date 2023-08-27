using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float WalkSpeed, JumpPower;
    public bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Walk = Input.GetAxis("Horizontal") * WalkSpeed /** Time.fixedDeltaTime*/;
        float Jump = Input.GetAxis("Jump") * JumpPower * Time.fixedDeltaTime;

        transform.Translate(Walk * Time.deltaTime, 0, 0);

        if (IsGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Jump));
        }
    }   
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "death")
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
