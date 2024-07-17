using System.Collections.Generic;
using DefaultNamespace;


public class AStar 
{

    public Dictionary<int, Node> OpenNodes = new Dictionary<int, Node>();
    public Dictionary<int, Node> CloseNodes = new Dictionary<int, Node>();

    private Node _curNode;
    
    public bool isBreak = false;

    public Node fromNode;
    public Node toNode;
    
    public AStar(Node fromNode,Node toNode)
    {
        this.fromNode = fromNode;
        this.toNode = toNode;
        //将初始起点加入到openList
        OpenNodes.Add(fromNode.id,fromNode);
    }
   
    
    
    public void AddStep()
    {
        //从OpenNode中取出一个最小F值的Node
        if (OpenNodes.Count == 0)    return;

        //挑选F值最小的，如果说F值一样，则挑选H值最小的，H值最小说明越接近目标
        // var minF = int.MaxValue;
        //
        // foreach (var node in OpenNodes.Values)
        // {
        //     if (node.F < minF)
        //     {
        //         _curNode = node;
        //         minF = node.F;
        //     }
        // }

        _curNode = null;
        
        foreach (var node in OpenNodes.Values)
        {
            if (_curNode == null)
            {
                _curNode = node;
                continue;
            }
            //挑选F值最小的，如果说F值一样，则挑选H值最小的，H值最小说明越接近目标
            if (_curNode.F >= node.F&& _curNode.H > node.H)
            {
                _curNode = node;
            }
        }
        
        
        //将其放入到closeNodes中
        OpenNodes.Remove(_curNode.id);
        CloseNodes.Add(_curNode.id,_curNode);
        
        _curNode.SetState(State.Purple);
        
        //将周围节点加入到OpenNode中并计算当前节点周围的值F值
        for (int xOffset = -1; xOffset <= 1; xOffset++)
        {
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                //排除自身
                if (xOffset == 0 && yOffset == 0) continue;

                //是否超出边界
                int x = (int)_curNode.Pos.x + xOffset;
                int y = (int) _curNode.Pos.y + yOffset;
                
                if (x < 0 || x >= NodeManager.Ins.colNum || y < 0 || y >= NodeManager.Ins.rowNum)
                {
                    continue;
                }

                var node = NodeManager.Ins.GetNode(x,y);
                
                //是否是可达
                if (!IsCanReach(_curNode, node))
                {
                    continue;
                }
                
                //添加到OpenNode中
                AddNodeToOpenNodesAndCalF(_curNode,node);
            }
        }
        
    }

    //能否从当前格子到目标格子（tarNode必须再curNode周围）
    //假设四个格子组成一个 田 如果说斜边两个格子都为障碍格子，那么剩下两个空格子路径是走不通的
    bool IsCanReach(Node curNode,Node tarNode)
    {
        if (tarNode.isObstacle) return false;
        
        //当两个格子为斜边并且田字格中的格子都为障碍或是空的时候不可达
        var offsetY = (int)(tarNode.Pos.y - curNode.Pos.y);
        var offsetX = (int)(tarNode.Pos.x - curNode.Pos.x);

        var offsetNodeX = NodeManager.Ins.GetNode((int) curNode.Pos.x + offsetX, (int) curNode.Pos.y);
        var offsetNodeY = NodeManager.Ins.GetNode((int) curNode.Pos.x, (int) curNode.Pos.y + offsetY);
        
        //如果说偏移格子其中一个为目标格子，说明目标格子不是不是斜边格子
        //斜边格子
        if (offsetNodeX != tarNode && offsetNodeY != tarNode)
        {
            if ((offsetNodeX == null || offsetNodeX.isObstacle) && (offsetNodeY == null || offsetNodeY.isObstacle))
            {
                return false;
            }
        }
      
        return true;
    }
    

    //加入到OpenNode中
    public void AddNodeToOpenNodesAndCalF(Node parent,Node node)
    {
        //在封闭格子中不处理
        if(CloseNodes.ContainsKey(node.id)) return;

        if (node == toNode)
        {
            isBreak = true;
            toNode.Parent = parent;

            var direction = parent.Pos - toNode.Pos;
            toNode.dir = Dir.VectorToIntMap[direction];
            
            return;
        }
        
        
        //是否已经添加过
        //没添加就计算F值并且添加
        if (!OpenNodes.ContainsKey(node.id))
        {
            OpenNodes.Add(node.id,node);
            //计算GH
            //是否同行或同列
            if (parent.Pos.x == node.Pos.x || parent.Pos.y == node.Pos.y)
            {
                node.G = parent.G + 10;
            }
            else
            {
                node.G = parent.G + 14;
            }
            node.H = node.ManHaDunDis(toNode)*10;
            
            node.SetState(State.Light);
            
            //设置父节点
            node.Parent = parent;
            var direction = parent.Pos - node.Pos;
            node.dir = Dir.VectorToIntMap[direction];

        }
        //比较G值大小判断是否要更新父节点
        else
        {
            int curG = 0;
            if (parent.Pos.x == node.Pos.x || parent.Pos.y == node.Pos.y)
            {
                curG = parent.G + 10;
            }
            else
            {
                curG = parent.G + 14;
            }

            //如果当前G值更小就跟新父节点
            if (curG < node.G)
            {
                node.G = curG;
                node.Parent = parent;
                var direction = parent.Pos - node.Pos;
                node.dir = Dir.VectorToIntMap[direction];
                
            }
        }
    }
    
}
