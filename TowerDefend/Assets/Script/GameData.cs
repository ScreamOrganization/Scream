using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{//脚本GameData : 继承Singleton<GameData> "(Singleton<T>)" 泛型的脚本书写方法 

    public int[] deblock = new int[]{1,0,0}; //关卡解锁情况，0-未解锁，1-已开放
    public float score;//分数

    private void Init()//私有的方法 用于使用单例  
    {
        //Init code  
    }
    void Awake()
    {
        this.Init();//引用单例  
    }
}  
