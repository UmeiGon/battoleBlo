using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyMove
{
    public static bool MoveSixDirection(float _speed,Transform move_obj)
    {
        if (MoveRight(_speed, move_obj)) return true;
        if (MoveLeft(_speed, move_obj)) return true;
        if (MoveForward(_speed, move_obj)) return true;
        if (MoveBack(_speed, move_obj)) return true;
        if (MoveUp(_speed, move_obj)) return true;
        if (MoveDown(_speed, move_obj)) return true;
        return false;
    }
    public static bool MoveFourDirection(float _speed, Transform move_obj)
    {
        if (MoveRight(_speed, move_obj)) return true;
        if (MoveLeft(_speed, move_obj)) return true;
        if (MoveForward(_speed, move_obj)) return true;
        if (MoveBack(_speed, move_obj)) return true;
        return false;
    }
    public static bool MoveRight(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.D))
        {
            move_obj.Translate(Vector3.right * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
    public static bool MoveLeft(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.A))
        {
            move_obj.Translate(Vector3.left * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
    public static bool MoveForward(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.W))
        {
            move_obj.Translate(Vector3.forward * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
    public static bool MoveBack(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.S))
        {
            move_obj.Translate(Vector3.back * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
    public static bool MoveUp(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            move_obj.Translate(Vector3.up * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
    public static bool MoveDown(float _speed, Transform move_obj)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move_obj.Translate(Vector3.down * Time.deltaTime * _speed);
            return true;
        }
        return false;
    }
}
