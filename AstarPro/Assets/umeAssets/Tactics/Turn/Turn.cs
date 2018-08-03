using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//なるだけ汎用的にしたいのでgenericにしている
public class Turn<Number>
{
    List<Number> numberList = new List<Number>();
    public void SetList(List<Number> number_list)
    {
        numberList = number_list;
        numbersEnumrator = GetTurnEnumrator();
        NextTurn();
    }
    IEnumerator<Number> GetTurnEnumrator()
    {
        while (true)
        {
            foreach (var i in numberList)
            {
                Debug.Log(i);
                yield return i;
            }
        }
    }
    IEnumerator<Number> numbersEnumrator;
    public Number CurrentTurn { get { return numbersEnumrator.Current; } }
    public Number NextTurn()
    {
        numbersEnumrator.MoveNext();
        return numbersEnumrator.Current;
    }
}
