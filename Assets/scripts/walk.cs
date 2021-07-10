using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    Rigidbody2D r;
    float speed =7;
    bool touchgr= true;
    // Start is called before the first frame update
    void Start()
    {
      r = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        //float MoveVertical = Input.GetAxis ("Vertical");
        float MoveHorizontal = Input.GetAxis("Horizontal");

        Vector2 MovePerso = new Vector2 (MoveHorizontal, 0);
        //r.AddForce (MovePerso * speed);
        r.velocity = MovePerso * speed;
       
        if(Input.GetKeyDown(KeyCode.Space)&&touchgr){
           Jump();
        }
        
    }
    void Jump(){
       Vector2 jump= new Vector2(0, 5*speed);
      r.velocity = jump;
    }
    void OnCollisionEnter2D(Collision2D Obj){
       if(Obj.gameObject.tag == "ground")
           touchgr=true;
       // print("the character is touching the ground");
          
    }
    void OnCollisionExit2D(Collision2D Obj){
       if(Obj.gameObject.tag == "ground")
            touchgr=false;
       // print("the character is no longer touching the ground");
    }
}
