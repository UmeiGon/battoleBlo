using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour
    where T :SingleTon<T>
{
    static T instance;
    private void Awake()
    {
        instance = (T)this;
    }
    public static T Instance
    {
        get
        {
            if (instance == null) return CompornentUtility.FindCompornentOnScene<T>();
            return instance;
        }
    }

}
