using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TestAnimationControls : MonoBehaviour
{
    public Animator anim;
    public float speed = 10f;
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(Input.GetButtonDown("Jump"))
        {
            
        }

        // check if player is moving
        if (translation != 0)
        {
            
        }
        else
        {
            
        }

        float verticalAnimParmeter = Input.GetAxis("Vertical") * 10;

        Debug.Log($"translation : {verticalAnimParmeter}");

        // apply movement
        anim.SetFloat("VelocityX", verticalAnimParmeter);

    }
}
