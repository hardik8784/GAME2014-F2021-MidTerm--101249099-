/*
 * Full Name: Hardik Dipakbhai Shah
 * Student ID : 101249099
 * Date Modified : October 19,2021
 * File : EnemyController.cs
 * Description : This is the Enemy Controller Script
 * Revision History : v0.1 > Added Comments to know the Code better before start anything & to include a program header
 *                    v0.2 > Added Enemy Movement 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public float horizontalBoundary;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Move()
    {
        //transform.position += new Vector3(horizontalSpeed * direction * Time.deltaTime, 0.0f, 0.0f);
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        //// check right boundary
        //if (transform.position.x >= horizontalBoundary)
        //{
        //    direction = -1.0f;
        //}

        //// check left boundary
        //if (transform.position.x <= -horizontalBoundary)
        //{
        //    direction = 1.0f;
        //}
        // check Top boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check Bottom boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
