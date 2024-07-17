using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

namespace DefaultNamespace
{
    public class JPS
    {
        public Dictionary<int, Node> OpenNodes = new Dictionary<int, Node>();
        public Dictionary<int, Node> CloseNodes = new Dictionary<int, Node>();

        public Node fromNode;
        public Node toNode;

        private Node _curNode;

        public bool IsBreak;
        
        public JPS(Node fromNode, Node toNode)
        {
            this.fromNode = fromNode;
            this.toNode = toNode;
            //将初始起点加入到openList
            OpenNodes.Add(fromNode.id, fromNode);
        }





        public void AddStep()
        {
            //从OpenNode中取出一个最小F值的Node
            if (OpenNodes.Count == 0|| IsBreak) return;


            _curNode = null;

            foreach (var node in OpenNodes.Values)
            {
                if (_curNode == null)
                {
                    _curNode = node;
                    continue;
                }

                //挑选F值最小的，如果说F值一样，则挑选H值最小的，H值最小说明越接近目标
                if (_curNode.F >= node.F && _curNode.H > node.H)
                {
                    _curNode = node;
                }
            }


            //将其放入到closeNodes中
            OpenNodes.Remove(_curNode.id);
            CloseNodes.Add(_curNode.id, _curNode);
            
            //根据当前节点，获取
            var dirListNode = GetNeighborNodes(_curNode);

            for (int i = 0; i < dirListNode.Count; i++)
            {
                var dirNode = dirListNode[i];
                var direction = dirNode.Pos - _curNode.Pos;

                //jumpNode实际上就是当前节点
                var jumpNode = SearchJumpNode(dirNode, direction);
                
                if (jumpNode != null)
                {
                    jumpNode.SetState(State.Purple);
                    
                    if (jumpNode == toNode)
                    {
                        //搜索结束
                        jumpNode.Parent = _curNode;
                        jumpNode.dir = Dir.VectorToIntMap[direction];
                        IsBreak = true;
                        return;
                    }
                    
                    //在封闭格子中说明处理过就跳过
                    if (CloseNodes.ContainsKey(jumpNode.id))
                    {
                        continue;
                    }

                    //计算GH值
                    int gValue;
                    //同行或同列
                    if (_curNode.Pos.x == jumpNode.Pos.x || _curNode.Pos.y == jumpNode.Pos.y)
                    {
                         gValue = (int)(Mathf.Abs(jumpNode.Pos.x - _curNode.Pos.x) * 10 +
                                     Mathf.Abs(jumpNode.Pos.y - _curNode.Pos.y) * 10);
                    }
                    //在斜边
                    else
                    {
                        gValue = (int) (Mathf.Abs(jumpNode.Pos.x - _curNode.Pos.x) * 14);
                    }
                    
                    //没添加过就计算兵添加
                    if (!OpenNodes.ContainsKey(jumpNode.id))
                    {
                        jumpNode.G = _curNode.G + (int)gValue;
                        jumpNode.H = jumpNode.ManHaDunDis(toNode) * 10;
                        jumpNode.Parent = _curNode;
                        
                        OpenNodes.Add(jumpNode.id,jumpNode);
                        
                    }
                    //已经在了的话,比较G值大小判断是否要更新父节点
                    else
                    {
                        if (gValue < jumpNode.G)
                        {
                            jumpNode.G = gValue;
                            jumpNode.Parent = _curNode;
                        }
                    }
                    
                    
                }
            }

        }

        /// <summary>
        /// 递归寻找跳点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        private Node SearchJumpNode(Node node,Vector2Int direction) 
        {
            //递归条件结束
            if (node == null|| node.isObstacle) return null;

            if (node == toNode)
            {
                return node;
            }
            
            
            //判断方向
            var dirX = (int) direction.x;
            var dirY = (int) direction.y;
            
            
            //UI刷新
            node.SetState(State.Light);
            node.dir = Dir.VectorToIntMap[direction];
            
            var nextNode = NodeManager.Ins.GetNode(node,  new Vector2Int(dirX, dirY));
            
            if (dirX != 0 && dirY != 0)
            {
                //判断有没有强迫邻居
                var dirXOppositeNode = NodeManager.Ins.GetNode(node,  new Vector2Int(-dirX, 0));
                var dirYOppositeNode = NodeManager.Ins.GetNode(node,  new Vector2Int(0, -dirY));

                if (dirXOppositeNode != null && dirXOppositeNode.isObstacle)
                {
                    var judgeNode = NodeManager.Ins.GetNode(dirXOppositeNode,  new Vector2Int(0, dirY));
                    if (judgeNode != null && !judgeNode.isObstacle)
                    {
                        return node;
                    }
                }
                        
                if (dirYOppositeNode != null && dirYOppositeNode.isObstacle)
                {
                    var judgeNode = NodeManager.Ins.GetNode(dirYOppositeNode,  new Vector2Int(dirX, 0));
                    if (judgeNode != null && !judgeNode.isObstacle)
                    {
                        return node;
                    }
                }
                
                //没有的转成两个分量进行搜索
                var dirXNode = NodeManager.Ins.GetNode(node,  new Vector2Int(dirX, 0));
                var dirYNode = NodeManager.Ins.GetNode(node,  new Vector2Int(0, dirY));

                var jumpPointDirX = SearchJumpNode(dirXNode, new Vector2Int(dirX, 0)); 
                if (jumpPointDirX!=null)
                {
                    return node;
                }
                
                
                var jumpPointDirY = SearchJumpNode(dirYNode, new Vector2Int(0, dirY)) ; 
                if (jumpPointDirY!=null)
                {
                    return node;
                }
            }
            //纵向
            else if (dirX == 0)
            {
                //判断是否有强迫邻居
                //绝对位置的右边节点
                var rightNode = NodeManager.Ins.GetNode(node,  new Vector2Int(1, 0));
              
                if (rightNode != null && rightNode.isObstacle)
                {
                    var rightNextNode = NodeManager.Ins.GetNode(node, new Vector2Int(1, dirY));
                    if (rightNextNode != null && !rightNextNode.isObstacle)
                    {
                        //当前节点极为跳点
                        return node;
                    }
                }
                
                var leftNode = NodeManager.Ins.GetNode(node,  new Vector2Int(-1, 0));
                if (leftNode != null && leftNode.isObstacle)
                {
                    var leftNextNode = NodeManager.Ins.GetNode(node,  new Vector2Int(-1, dirY));
                    if (leftNextNode != null && !leftNextNode.isObstacle)
                    {
                        //当前节点极为跳点
                        return node;
                    }
                }
                
               
            }
            //横向
            else if(dirY == 0)
            {
                //判断是否有强迫邻居
                //绝对位置的右边节点
                var upNode = NodeManager.Ins.GetNode(node,  new Vector2Int(0, 1));
              
                if (upNode != null && upNode.isObstacle)
                {
                    var upNextNode = NodeManager.Ins.GetNode(node,  new Vector2Int(dirX, 1));
                    if (upNextNode != null && !upNextNode.isObstacle)
                    {
                        //当前节点极为跳点
                        return node;
                    }
                }
                
                var downNode = NodeManager.Ins.GetNode(node,  new Vector2Int(0, -1));
                if (downNode != null && downNode.isObstacle)
                {
                    var downNextNode = NodeManager.Ins.GetNode(node,  new Vector2Int(dirX, -1));
                    if (downNextNode != null && !downNextNode.isObstacle)
                    {
                        //当前节点极为跳点
                        return node;
                    }
                }
            }
            
            return SearchJumpNode(nextNode, direction);
        }
        
        
        
        private List<Node> GetNeighborNodes(Node curNode)
        {

            List<Node> result = new List<Node>();

            //说明为初始节点，则获取周围一圈节点
            if (curNode.Parent == null)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    for (int yOffset = -1; yOffset <= 1; yOffset++)
                    {
                        //排除自身
                        if (xOffset == 0 && yOffset == 0) continue;

                        //是否超出边界
                        int x = (int) curNode.Pos.x + xOffset;
                        int y = (int) curNode.Pos.y + yOffset;

                        if (x < 0 || x >= NodeManager.Ins.colNum || y < 0 || y >= NodeManager.Ins.rowNum)
                        {
                            continue;
                        }

                        var node = NodeManager.Ins.GetNode(x, y
                        );

                        if (node.isObstacle) continue;

                        result.Add(node);

                    }
                }
            }
            //说明不为初始节点
            else
            {
                //计算方向
                var dirX = (int) (curNode.Pos.x - curNode.Parent.Pos.x);
                var dirY = (int) (curNode.Pos.y - curNode.Parent.Pos.y);

                dirX = dirX > 0 ? 1 : dirX == 0 ? 0 : -1;
                dirY = dirY > 0 ? 1 : dirY == 0 ? 0 : -1;

                //判断是直线移动还是斜线移动

                var nextNode = NodeManager.Ins.GetNode((int) curNode.Pos.x + dirX, (int) curNode.Pos.y + dirY);
                if (nextNode != null)
                {
                    if (!nextNode.isObstacle)
                    {
                        result.Add(nextNode);
                    }
                }

                //绝对位置的四个节点

                //直线
                if (dirX == 0 || dirY == 0)
                {
                      //将强迫邻居也添加进去
                        //横向
                        if (dirY == 0)
                        {
                            var upNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(0, 1));
                            var downNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(0, -1));

                            if (upNode != null && upNode.isObstacle)
                            {
                                var nextUpNode = NodeManager.Ins.GetNode(nextNode,  new Vector2Int(0, 1));
                                if (nextUpNode != null && !nextUpNode.isObstacle)
                                {
                                    result.Add(nextUpNode);
                                }
                            }

                            if (downNode != null && downNode.isObstacle)
                            {
                                var nextDownNode = NodeManager.Ins.GetNode(nextNode,  new Vector2Int(0, -1));
                                if (nextDownNode != null && !nextDownNode.isObstacle)
                                {
                                    result.Add(nextDownNode);
                                }
                            }
                        }

                        //纵向
                        if (dirX == 0)
                        {
                            var rightNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(1, 0));
                            var leftNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(-1, 0));

                            if (rightNode != null && rightNode.isObstacle)
                            {
                                var nextRightNode = NodeManager.Ins.GetNode(nextNode,  new Vector2Int(1, 0));
                                if (nextRightNode != null && !nextRightNode.isObstacle)
                                {
                                    result.Add(nextRightNode);
                                }
                            }

                            if (leftNode != null && leftNode.isObstacle)
                            {
                                var nextLeftNode = NodeManager.Ins.GetNode(nextNode,  new Vector2Int(-1, 0));
                                if (nextLeftNode != null && !nextLeftNode.isObstacle)
                                {
                                    result.Add(nextLeftNode);
                                }
                            }
                        }
                }
                //斜线
                else
                {
                    var dirXNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(dirX, 0));
                    var dirYNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(0, dirY));

                    if (dirXNode != null && !dirXNode.isObstacle)
                    {
                        result.Add(dirXNode);
                    }

                    if (dirYNode != null && !dirYNode.isObstacle)
                    {
                        result.Add(dirYNode);
                    }

                    //如果有强迫邻居的话也添加
                    var dirXOppositeNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(-dirX, 0));
                    var dirYOppositeNode = NodeManager.Ins.GetNode(curNode,  new Vector2Int(0, -dirY));

                    if (dirXOppositeNode != null && dirXOppositeNode.isObstacle)
                    {
                        var judgeNode = NodeManager.Ins.GetNode(dirXOppositeNode,  new Vector2Int(0, dirY));
                        if (judgeNode != null && !judgeNode.isObstacle)
                        {
                            result.Add(judgeNode);
                        }
                    }

                    if (dirYOppositeNode != null && dirYOppositeNode.isObstacle)
                    {
                        var judgeNode = NodeManager.Ins.GetNode(dirYOppositeNode,  new Vector2Int(dirX, 0));
                        if (judgeNode != null && !judgeNode.isObstacle)
                        {
                            result.Add(judgeNode);
                        }
                    }
                }
                

                
            }


            return result;
        }
    }
}