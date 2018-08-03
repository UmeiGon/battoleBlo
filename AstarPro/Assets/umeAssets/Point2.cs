using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Point2
{
    public bool isEmpty;
    public int x;
    public int y;
    public Point2(int _x, int _y,bool is_empty=false)
    {
        x = _x;
        y = _y;
        isEmpty = is_empty;
    }
    public Point2 ToAbs()
    {
        return new Point2(Mathf.Abs(x),Mathf.Abs(y));
    }
    public int GetSum()
    {
        return x + y;
    }
    public int AbsSum()
    {
        return Mathf.Abs(x) + Mathf.Abs(y);
    }
    public static bool operator ==(Point2 _a,Point2 _b)
    {
        return (_a.x==_b.x&&_a.y==_b.y);
    }
    public static bool operator !=(Point2 _a, Point2 _b)
    {
        return (_a.x != _b.x || _a.y != _b.y);
    }
    public static Point2 operator +(Point2 _a, Point2 _b)
    {
        return new Point2(_a.x + _b.x, _a.y + _b.y);
    }
    public static Point2 operator -(Point2 _a, Point2 _b)
    {
        return new Point2(_a.x - _b.x, _a.y - _b.y);
    }
    public static Point2 Empty
    {
        get { return new Point2(0, 0, true); }
    }
    public static Point2 ForWard
    {
        get { return new Point2(0, 1); }
    }
    public static Point2 Right
    {
        get { return new Point2(1, 0); }
    }
    public static Point2 operator -(Point2 _a)
    {
        return new Point2(-_a.x, -_a.y);
    }
    public static List<Point2> GetFourDir()
    {
        var blist = new List<Point2>
        {
            Right,
            ForWard,
            -Right,
            -ForWard
        };
        return blist;
    }
}
