/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : PlayerController.cs
 * Description : This is the Player Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added Player movement vertically
 */


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float horizontalBoundary;
    public float verticalBoundary;                  //Indicate vertical Boundary

    [Header("Player Speed")]
    public float horizontalSpeed;
    public float verticalSpeed;                     //Indicate Vertical Speed
    public float maxSpeed;
    public float horizontalTValue;
    public float verticalTValue;                    //VerticalTValue

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        //// keyboard support check to see out of bounds, *Not asked into the Midterm so comment out*
        //if (Input.GetAxis("Vertical") >= 4.0f)
        //{
        //    // direction is positive
        //    direction = 1.0f;
        //}

        //if (Input.GetAxis("Vertical") <= -4.0f)
        //{
        //    // direction is negative
        //    direction = -1.0f;
        //}

        if (m_touchesEnded.y != 0.0f)
        {
            //transform.position = new Vector2(Mathf.Lerp(transform.position.x, m_touchesEnded.x, horizontalTValue), transform.position.y);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue));     //X position is fixed, Y needs to change
        }
        else
        {
            //Vector2 newVelocity = m_rigidBody.velocity + new Vector2(direction * horizontalSpeed, 0.0f);
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);          //Y direction needs to change where x is same
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        //// check right bounds
        //if (transform.position.x >= horizontalBoundary)
        //{
        //    transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
        //}

        //// check left bounds
        //if (transform.position.x <= -horizontalBoundary)
        //{
        //    transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
        //}

        // check top bounds
        if (transform.position.y >= verticalBoundary)                                                       //Checks the Y Top bound,if it is equal to or greater than vertical boundary then it stays there
        {
            // transform.position = new Vector3(horizontalBoundary, transform.position.y, 0.0f);
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check bottom bounds
        if (transform.position.y <= -verticalBoundary)                                                       //Checks the Y Bottom bound,if it is equal to or less than -(vertical boundary) then it stays there
        {
            //transform.position = new Vector3(-horizontalBoundary, transform.position.y, 0.0f);
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }
}
