using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using State = DefaultNamespace.State;

public class Main : SingletonMon<Main>
{

    public int GameState = 0;
    private AStar _aStar;
    private JPS _jps;
    void Start()
    {
        NodeManager.Ins.InitMap();
        //AStar aStar = new AStar();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            this.GameState = GameStated.ClickFromNode;
        }
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            this.GameState = GameStated.ClickToNode;
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            this.GameState = GameStated.ClickBlock;
        }
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.GameState = GameStated.GameStart;
             //_aStar = new AStar(NodeManager.Ins.fromNode,NodeManager.Ins.toNode);
             _jps = new JPS(NodeManager.Ins.fromNode, NodeManager.Ins.toNode);
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (_jps.IsBreak)
            {
                var tempNode = _jps.toNode;
                while (tempNode.Parent != null)
                {
                    tempNode.Parent.SetState(State.Yellow);
                    tempNode = tempNode.Parent;
                   
                    NodeManager.Ins.UpdateAllGrid();
                }
                return;
            }
            
            _jps.AddStep();
            NodeManager.Ins.UpdateAllGrid();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GameState = GameStated.GameStart;
            _aStar = new AStar(NodeManager.Ins.fromNode,NodeManager.Ins.toNode);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_aStar.isBreak)
            {
                var tempNode = _aStar.toNode;
                while (tempNode.Parent != null)
                {
                    tempNode.Parent.SetState(State.Yellow);
                    tempNode = tempNode.Parent;
                    NodeManager.Ins.UpdateAllGrid();
                }
                
                return;
            }
            
            _aStar.AddStep();
            NodeManager.Ins.UpdateAllGrid();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
           NodeManager.Ins.ClearFindPathData();
           NodeManager.Ins.UpdateAllGrid();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            NodeManager.Ins.ClearAllMapData();
            NodeManager.Ins.UpdateAllGrid();
        }

       
    }
}
