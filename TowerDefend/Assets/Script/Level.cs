﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelType
{
    lv_1,
    lv_2,
    lv_3
}

//玩家- -1，空白地块（可建造）-0，我方基地-1，地方堡垒-2，河流-3，小桥-4 ，外墙-5
public enum TilesType
{
    player = -1,
    floor = 0,
    myBase = 1,
    enemyBase = 2,
    river = 3,
    bridge = 4,
    outerWall = 5,

    //塔防 11-30
    stand = 11,  //标准炮塔
    Laser = 12,  //激光炮塔

    //怪物 31-??


}

[System.Serializable]
public class Level
{
    public  LevelType lv;

    //地图1
    public static int[,] map_1 = new int[,] {
         {0, 0, 0, 0, 0, 0, 0, 0, 0},   
         {0, 0, 0, 0, 12, 0, 0, 0, 0},
         {0, 0, 11, 0, 0, 0, 11, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
		 {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
		 {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {3, 3, 4, 3, 3, 3, 4, 3, 3},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
		 {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
		 {0, 0, 0, 0, -1, 0, 0, 0, 0},
         {0, 0, 0, 0, 1, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
   };

    //地图2
    public static int[,] map_2 = new int[,] {
         {0, 0, 0, 0, 0, 0, 0, 0, 0},   
         {0, 0, 0, 0, 11, 0, 0, 0, 0},
         {0, 0, 12, 0, 0, 0, 12, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 4, 4, 4, 0, 4, 4, 4, 0},
		 {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 5, 0, 0, 0, 5, 0, 0},
		 {0, 0, 5, 0, 0, 0, 5, 0, 0},
         {0, 0, 0, 0, 4, 0, 0, 0, 0},
         {0, 0, 0, 0, 4, 0, 0, 0, 0},
		 {0, 0, 0, 0, 0, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
		 {0, 0, 0, 0, -1, 0, 0, 0, 0},
         {0, 0, 0, 0, 1, 0, 0, 0, 0},
         {0, 0, 0, 0, 0, 0, 0, 0, 0},
   };

   //地图3
   public static int[,] map_3 = new int[,] {
         {5, 0, 2, 0, 0, 0, 2, 0, 5},   
         {5, 0, 0, 0, 12, 0, 0, 0, 5},
         {5, 0, 12, 0, 0, 0, 12, 0, 5},
         {5, 0, 0, 0, 0, 0, 0, 0, 5},
         {5, 0, 0, 0, 0, 0, 0, 0, 5},
		 {12, 0, 0, 3, 0, 3, 0, 0, 12},
         {5, 0, 0, 0, 0, 0, 0, 0, 5},
         {5, 0, 0, 0, 0, 0, 0, 0, 5},
		 {5, 0, 0, 0, 0, 0, 0, 0, 5},
         {5, 0, 0, 3, 0, 3, 0, 0, 5},
         {5, 0, 0, 0, -1, 0, 0, 0, 5},
		 {5, 0, 0, 0, 0, 0, 0, 0, 5},
         {5, 0, 0, 0, 0, 0, 0, 0, 5},
		 {5, 0, 0, 0, 0, 0, 0, 0, 5},
         {5, 0, 0, 0, 1, 0, 0, 0, 5},
         {12, 0, 0, 0, 0, 0, 0, 0, 12},
   };
}
