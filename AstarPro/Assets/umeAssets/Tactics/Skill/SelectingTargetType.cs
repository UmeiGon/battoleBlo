using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どんな感じで指定するかを決める
public abstract class SelectingTargetType  {
    //selectした場合nullを返し、しなかった場合nullを返す。
    public abstract List<Point2> Selecting(Unit _user,KeyCode _key);
}
