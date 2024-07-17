using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Node
    {
        public int id;
        public Vector2Int Pos;

        public Node Parent;
    
        public bool isObstacle = false;

        private int State;

        public int dir = -1;


        public void Rest()
        {
            this.Parent = null;
            this.State = 0;
            this.dir = -1;
            this.G = 0;
            this.H = 0;
            isObstacle = false;
        }
        
        public int F
        {
            get { return G + H;}
            private set{}
        }
        public int G;
        public int H;

        //游戏未开始设置
        public void SetStateOnly(int state)
        {
            this.State = state;
        }
    
    
        public void SetState(int state)
        {
            //高的可以覆盖低的
            if (state > this.State)
            {
                this.State = state;
            }
        }

        public int GetState()
        {
            return State;
        }
    
        public  int ManHaDunDis(Node other)
        {
            return (int)(Math.Abs(other.Pos.x - Pos.x) + Math.Abs(other.Pos.y - Pos.y));
        }

        
    }
    
    public static class Dir
    {
        public static int Up = 1;
        public static int Right = 2;
        public static int Down = 3;
        public static int Left = 4;
        public static int UpRight = 5;
        public static int DownRight = 6;
        public static int DownLeft = 7;
        public static int UpLeft = 8;

        public static Vector2Int UpVector = Vector2Int.up;
        public static Vector2Int RightVector = Vector2Int.right;
        public static Vector2Int DownVector = Vector2Int.down;
        public static Vector2Int LeftVector = Vector2Int.left;
        public static Vector2Int UpRightVector = new Vector2Int(1, 1);
        public static Vector2Int DownRightVector = new Vector2Int(1, -1);
        public static Vector2Int DownLeftVector = new Vector2Int(-1, -1);
        public static Vector2Int UpLeftVector = new Vector2Int(-1, 1);
        
        
        public static Dictionary<int, Vector2Int> IntToVectorMap = new Dictionary<int, Vector2Int>()
        {
            {1, Vector2Int.up},
            {2, Vector2Int.right},
            {3, Vector2Int.down},
            {4, Vector2Int.left},
            {5, new Vector2Int(1, 1)},
            {6, new Vector2Int(1, -1)},
            {7, new Vector2Int(-1, -1)},
            {8, new Vector2Int(-1, 1)},
        };

        public static Dictionary<Vector2Int,int > VectorToIntMap = new Dictionary<Vector2Int,int>()
        {
            { Vector2Int.up,Up},
            { Vector2Int.right,Right},
            { Vector2Int.down,Down},
            { Vector2Int.left,Left},
            { new Vector2Int(1, 1),UpRight},
            { new Vector2Int(1, -1),DownRight},
            { new Vector2Int(-1, -1),DownLeft},
            { new Vector2Int(-1, 1),UpLeft},

        };
        
      
    }

    /// <summary>
    /// 黑色：障碍格子
    /// 绿色：起点
    /// 蓝色：终点
    /// 紫色：被当过当前节点
    /// 青色：被添加到过OpenNodes
    /// 白色：空各格子
    /// </summary>
    public static class State
    {
        public const int White = 0;
        public const int Light = 1;
        public const int Purple = 2;
        public const int Yellow = 3;
        public const int Blue = 4;
        public const int Green = 5;
        public const int Black = 6;
   
    }

}