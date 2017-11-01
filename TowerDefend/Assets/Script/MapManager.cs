using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;
public class MapManager : MonoBehaviour {

    public Level level ;
    public GameObject player;                   //玩家
    public GameObject myBase;                 //我方基地
    public GameObject[] enemyBase;              //敌方基地
    public GameObject[] floorTiles;           //地板的预制体数组  
    public GameObject[] outerWallTiles;       //外墙的数组
    public GameObject[] riverTiles;           //河流的数组
    public GameObject[] bridge;                 //小桥
	[Space]
	[Header("塔防预设")]
	public static int turretCount = 0;
    public GameObject standTurret;          //标准炮塔
    public GameObject laserTurret;          //激光炮塔 

    private Transform boardHolder;            //整理层级面板用的
	// Use this for initialization
	void Start () {
        //print(GameData.Instance.deblock[0]);
        DestroyMap();
        SelectLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //选择关卡
    void SelectLevel()
    {
        int[,] map = new int[,] { };
        if (level.lv == LevelType.lv_1)
        {
            map = Level.map_1;
        }
        else if (level.lv == LevelType.lv_2)
        {
            map = Level.map_2;
        }
        else if (level.lv == LevelType.lv_3)
        {
            map = Level.map_3;
        }

        BoardSetup(map);
    }

    //初始化生成地图
    void BoardSetup(int[,] map)
    {
        boardHolder = new GameObject("Board").transform;
 
        int posX = map.GetLength(0);
        int posY = map.GetLength(1);
        for (int x = 0; x < posX; x++)
        {
            for (int y = 0; y < posY; y++)
            {
                switch (map[x, y])
                {
                    case (int)TilesType.player:
                        SetStandTiles(player, new Vector3(y, posX - x, 0f),null);
                        break;

                    case (int)TilesType.floor:
                        SetTiles(floorTiles, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.myBase:
                        SetStandTiles(myBase, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.enemyBase:
                        SetTiles(enemyBase, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.river:
                        SetTiles(riverTiles, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.bridge:
                        SetTiles(bridge, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.outerWall:
                        SetTiles(outerWallTiles, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.stand:
                        SetStandTiles(standTurret, new Vector3(y, posX - x, 0f), boardHolder);
                        break;

                    case (int)TilesType.Laser:
                        SetStandTiles(laserTurret, new Vector3(y, posX - x, 0f), boardHolder);
                        break;
                }
				if(map[x, y]>=11&& map[x, y]<30)
				{
					turretCount += 1;
				}
            }
        }
    }

    //设置地块(随机)
    void SetTiles(GameObject[] tiles,Vector3 vec,Transform board) 
    {
        GameObject toInstantiate = tiles[Random.Range(0, tiles.Length)];
        GameObject instance = Instantiate(toInstantiate, vec, Quaternion.identity) as GameObject;
        instance.transform.SetParent(board);//设置生成物体的父物体
    }

    //设置地块(固定)
    void SetStandTiles(GameObject tiles, Vector3 vec, Transform board)
    {
        GameObject instance = Instantiate(tiles, vec, Quaternion.identity) as GameObject;
		if(board!=null)
        instance.transform.SetParent(board);//设置生成物体的父物体
    }

    //随机生成关卡（测试用）
    public void RandomLevel()
    {
        DestroyMap();

        int[,] map = new int[Level.map_1.GetLength(0), Level.map_1.GetLength(1)];
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int i = Random.Range(0, TilesType.GetNames(typeof(TilesType)).Length *3);
                if (i > TilesType.GetNames(typeof(TilesType)).Length - 1 && i!=11 && i !=12)
                    i = 0;
               map[x, y] = i;
            }
        }
        BoardSetup(map);
    }

    void DestroyMap()
    {
        GameObject mapBoard = GameObject.Find("Board");
        if (null != mapBoard)
        {
            DestroyImmediate(mapBoard);

        }
    }

}


