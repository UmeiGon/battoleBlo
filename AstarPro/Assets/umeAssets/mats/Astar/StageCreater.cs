using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField] GameObject wallPre;
    [SerializeField] GameObject roadPre;
    [SerializeField] GameObject iroOrePre;
    [SerializeField] GameObject emeOrePre;
    [SerializeField] GameObject flagPre;
    List<Point2> flagList = new List<Point2>();
    const int mapW = 19;
    const int mapH = 19;
    int[,] map = new int[mapW, mapH]
    {
        {2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,3,3,3,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,3,3,3,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,3,3,3,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2},
    };
    int[,] heightmap = new int[mapW, mapH]
   {
        {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1},
   };
    GameObject GetPreBlock(int num)
    {
        GameObject block = null;
        switch (num)
        {
            case 0:
                block = roadPre;
                break;
            case 1:
                block = wallPre;
                break;
            case 2:
                block = emeOrePre;
                break;
            case 3:
                block = iroOrePre;
                break;
        }
        return block;
    }
    BattleStage battleStage;
    void CreateBlock(GameObject pre_obj, Point2 block_point, int map_height)
    {
        
        for (int h = 0; h <= map_height; h++)
        {
            GameObject block = Instantiate(pre_obj);
            block.GetComponentInChildren<BlockPointGetter>().point = block_point;
            block.transform.position = new Vector3(block_point.x, h * 0.5f, block_point.y);
            if (h == map_height)
            {
                battleStage.AddBlock(block_point, new BattleBlock(map_height, block.transform));
            }
      
        }
        if (flagList.Contains(block_point))
        {
            GameObject flag = Instantiate(flagPre);
            flag.transform.position = new Vector3(block_point.x,0 , block_point.y);
        }
    }
    public void CreateStage()
    {
        battleStage = CompornentUtility.FindCompornentOnScene<BattleStage>();
        flagList.Add(new Point2(1, 1));
        flagList.Add(new Point2(mapW / 2 , mapH / 2 ));
        flagList.Add(new Point2(mapW - 2, mapH - 2));
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int mapType = map[x, y];
                int mapHeight = heightmap[x, y];
                GameObject blockPre = GetPreBlock(mapType);
                Point2 blockPoint = new Point2(x, y);
                CreateBlock(blockPre, blockPoint, mapHeight);
            }
        }
    }
}
