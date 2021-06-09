using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction{
    Right,
    Left,
    Middle
}

public class PlayerMovement : MonoBehaviour
{
    private float speed=0.04f,speedlast;
    private Direction direction;

    void Update()
    {
        if(Input.touchCount>0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                TurnBack();
                SetDirection();
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Hold();
                SetDirection();
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                speed=speedlast;
                SetDirection();
            }
            
        }
        //Input.GetTouch(0).position.y < Screen.height / 2) && Input.GetTouch(0).phase == TouchPhase.Began
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody>().AddRelativeForce(Vector3.right*speed);
        transform.Translate(Vector3.right*speed,Space.World);
    }

    void TurnBack()
    {
        speed*=-1;
        speedlast=speed;        
    }

    void Hold()
    {
        speed=0f;
    }

    void SetDirection()
    {
        if(speed>0) 
        {
            direction=Direction.Right;
            //ResetDirection();
        }
        else if(speed<0) 
        {
            direction=Direction.Left;
            //ResetDirection();
        }
        else direction=Direction.Middle;
        //GetComponent<SpriteRenderer>().color=new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
        TurnSpriteToDiretcion(direction);
    }

    public Direction GetDirection(){
        return direction;
    }

    void TurnSpriteToDiretcion(Direction dir)
    {
        if(dir==Direction.Left) GetComponent<SpriteRenderer>().flipX=true;
        else if(dir==Direction.Right) GetComponent<SpriteRenderer>().flipX=false;
        //else if(dir==Direction.Middle) this.transform.localRotation=Quaternion.Euler(0f,0f,45f);
    }

    /*void ResetDirection()
    {
        this.transform.localRotation=Quaternion.Euler(0f,0f,0f);
    }*/
}
