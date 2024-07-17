using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using State = DefaultNamespace.State;

public class UINode : MonoBehaviour , IPointerDownHandler
{

    public int Id = 0;
    
    
    
    public Image ImgArrow;
    public Text TxtF;
    public Text TxtG;
    public Text TxtH;
    public Image Bg;
    public Text TxtId;

    public void Refresh(Node node)
    {
        RefreshColor(node.GetState());
        RefreshFGH(node);
        RefreshArrow(node);
        
    }

    private void RefreshArrow(Node node)
    {
        ImgArrow.enabled = node.dir != -1;
        
        
        SetRowDirection(node.dir);
    }
    
    
    public void RefreshArrowByParent(Node node)
    {
        if (node.Parent == null)
        {
           
            return;
        }
        
        //箭头方向
        //右
        if (node.Pos.x + 1 == node.Parent.Pos.x && node.Pos.y == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.Right);
        }
        //右下
        if (node.Pos.x + 1 == node.Parent.Pos.x && node.Pos.y -1 == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.DownRight);
        }
        //下
        if (node.Pos.x  == node.Parent.Pos.x && node.Pos.y -1 == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.Down);
        }
        //左下
        if (node.Pos.x -1 == node.Parent.Pos.x && node.Pos.y -1 == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.DownLeft);
        }
        //左
        if (node.Pos.x -1 == node.Parent.Pos.x && node.Pos.y  == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.Left);
        }
        //左上
        if (node.Pos.x -1 == node.Parent.Pos.x && node.Pos.y + 1  == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.UpLeft);
        }
        //上
        if (node.Pos.x  == node.Parent.Pos.x && node.Pos.y + 1  == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.Up);
        }
        //右上
        if (node.Pos.x +1 == node.Parent.Pos.x && node.Pos.y + 1  == node.Parent.Pos.y)
        {
            SetRowDirection(Dir.UpRight);
        }
       
    }


    private void SetRowDirection(int dir)
    {
       
        switch (dir)
        {
            //上
            case 1:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-270);
                break;
            //右
            case 2:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,0);
                break;
            //下
            case 3:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-90);
                break;
            //左
            case 4:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-180);
                break;
            //右上
            case 5:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-315);
                break;
            //右下
            case 6:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-45);
                break;
            //左下
            case 7:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-135);
                break;
            //左上
            case 8:
                ImgArrow.rectTransform.rotation = Quaternion.Euler(0,0,-225);
                break;
        }
        
    }
    
    
    public void SetRowDirection(Vector2 dir)
    {
        
        ImgArrow.enabled = true;
        //上
        if (dir == Dir.UpVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -270);
        }

        //右
        if (dir == Dir.RightVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //下
        if (dir == Dir.DownVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -90);
        }

        //左
        if (dir == Dir.LeftVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -180);
        }

        //右上
        if (dir == Dir.UpRightVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -315);
        }

        //右下
        if (dir == Dir.DownRightVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -45);
        }

        //左下
        if (dir == Dir.DownLeftVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -135);
        }

        //左上
        if (dir == Dir.UpLeftVector)
        {
            ImgArrow.rectTransform.rotation = Quaternion.Euler(0, 0, -225);
        }
    }
    
    public void RefreshFGH(Node node)
    {
        TxtF.text = "F:" + node.F;
        TxtG.text = "G:" + node.G;
        TxtH.text = "H:" + node.H;
        TxtId.text = "Id:" + node.id;
    }

    public void RefreshColor(int state)
    {
        switch (state)
        {
            case State.Black:
                Bg.color = Color.black;
                break;
            case State.Blue:
                Bg.color = Color.blue;
                break;
            case State.Green:
                Bg.color = Color.green;
                break;
            case State.Light:
                Bg.color = Color.cyan;
                break;
            case State.Purple:
                Bg.color = Color.magenta;
                break;
            case State.White:
                Bg.color = Color.white;
                break;
            case State.Yellow:
                Bg.color = Color.yellow;
                break;
        }
        
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (Main.Ins.GameState == GameStated.GameStart)
        {
            return;
        }

        if (Main.Ins.GameState == GameStated.ClickBlock) NodeManager.Ins.SetNodeState(this.Id,State.Black);
        if (Main.Ins.GameState == GameStated.ClickFromNode)   NodeManager.Ins.SetNodeState(this.Id,State.Green);
        if (Main.Ins.GameState == GameStated.ClickToNode)   NodeManager.Ins.SetNodeState(this.Id,State.Blue);
        
        NodeManager.Ins.RefreshById(Id);    
    }
}
