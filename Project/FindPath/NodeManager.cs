using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class NodeManager: MonoSingleton<NodeManager>
    {
        
        public  readonly int rowNum = 10;
        public  readonly int colNum = 17;
        
        private Node[,] nodeArray;
        private Dictionary<int, Node> nodeMap = new Dictionary<int, Node>(); 
    
        public Node fromNode;
        public Node toNode;
    
        public List<UINode> UINodes = new List<UINode>();

        public Node GetNode(int x, int y)
        {
            if (x < 0 || x >= NodeManager.Ins.colNum || y < 0 || y >= NodeManager.Ins.rowNum)
            {
                return null;
            }

            return nodeArray[y, x];
        }

        public UINode GetUINode(int id)
        {
            if (id < UINodes.Count && UINodes[id] != null)
            {
                return UINodes[id];
            }

            return null;
        }
        
        
        public Node GetNode(int id)
        {
            if (nodeMap.ContainsKey(id))
            {
                return nodeMap[id];    
            }

            return null;
        }

        public void ClearAllMapData()
        {
            foreach (var node in nodeArray)
            {
                node.Rest();
            }
        }

        public void ClearFindPathData()
        {
            foreach (var node in nodeArray)
            {
                if(node.isObstacle) continue;
                if(node== fromNode) continue;
                if (node == toNode)
                {
                    node.dir = -1;
                    continue;
                }
                
                node.Rest();
            }
        }
        
        
        public void InitMap()
        {
            //初始化地图数据
            int id = 0;
            List<int> tempId = new List<int>();

            nodeArray = new Node[rowNum, colNum];
            
            for (int y = 0; y < rowNum; y++)
            {
                for (int x = 0; x < colNum; x++)
                {
                    var node = new Node() {id = id,Pos = new Vector2Int(x, y)};
                    nodeArray[y, x] = node;
                    nodeMap.Add(id,node);

                    UINodes[id].Id = id; 
                
                    tempId.Add(id);
                    id++; 
                }
            
            }
            UpdateAllGrid();
        }
        
        public void RefreshById(int id)
        {
            var node = nodeMap[id];
            UINodes[id].Refresh(node);
        }
        
        /// <summary>
        /// 黑色：障碍格子
        /// 绿色：起点
        /// 蓝色：终点
        /// 紫色：被当过当前节点
        /// 青色：被添加到过OpenNodes
        /// 白色：空各格子
        /// </summary>
        public void UpdateAllGrid()
        {
            for (int i = 0; i < UINodes.Count; i++)
            {
                var uiNode = UINodes[i];
                var node = nodeMap[i];
                uiNode.Refresh(node);
            }
        }
        
        
        public void SetNodeState(int id,int state)
        {
            var node = GetNode(id);
            if (state == State.Black)
            {
                node.isObstacle = true;    
            }

            if (state == State.Blue)
            {
                if (toNode != null)
                {
                    toNode.SetStateOnly(State.White);
                    RefreshById(toNode.id);
                }
                toNode = node;
                toNode.SetStateOnly(State.Blue);
                RefreshById(toNode.id);
            
            }
            if (state == State.Green)
            {
                if (fromNode != null)
                {
                    fromNode.SetStateOnly(State.White);
                    RefreshById(fromNode.id);
                }
                fromNode = node;
                fromNode.SetStateOnly(State.Green);
                 RefreshById(fromNode.id);

            }
            node.SetState(state);
        }

        public Node GetNode(Node curNode, Vector2Int offset)
        {
            var x = (int)(curNode.Pos.x + offset.x);
            var y = (int)(curNode.Pos.y + offset.y);
            
            if (x < 0 || x >= colNum || y < 0 || y >= rowNum)
            {
                return null;
            }
            
            return nodeArray[y, x];
        }
    }
    
    
}