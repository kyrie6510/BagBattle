using System.Collections.Generic;
using Game;
using Game.Game;
using Unity.VisualScripting;

public partial class GameEntity
{
    public void DoAction()
    {
       //EventManager.Instance.TriggerEvent(new OnLog($"冷却完成{localId.value}"));

        // if (CanAttack())
        // {
        //    var Id = actorId.Value == 0? 1: 0;
        //    var actor = Contexts.sharedInstance.actor.GetEntityWithId(Id);
        //    var v = UtilityRandom.random.Next((int)attack.Value[0], (int)attack.Value[1] + 1);
        //    actor.ReplaceHp(actor.hp.MaxValue,actor.hp.Value- v);
        // }
        
    }

    // public bool CanAttack()
    // {
    //     return attack.Value[0] != 0 || attack.Value[1] != 0;
    // }

    private Dictionary<char, int> NumMap = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };
    
    
 
    private Dictionary<int,string > CharMap = new Dictionary<int,string >()
    {
        {1,"I"}, 
        {5,"V"}, 
        {10,"X"}, 
        {50,"L"}, 
        {100,"C"}, 
        {500,"D"}, 
        {1000,"M"}, 
        {4,"IV"},
        {9,"IX"},
        {40,"XL"},
        {90,"XC"},
        {400,"CD"},
        {900,"CM"},
    };
    
    
    public int RomanToInt(string s)
    {

        int res = 0;
        int i = 0;
        for (i = 0; i < s.Length-1; i++)
        {
            var c = s[i];
            var cNext = s[i + 1];
            
            //小 大 = 大 - 小
            if (NumMap[c] < NumMap[cNext]&& (c == 'I'|| c=='X'|| c== 'C'))
            {
                res += NumMap[cNext] - NumMap[c];
                i++;
            }
            else
            {
                res += NumMap[c];
            }
            
        }

        if (i <= s.Length - 1)
        {
            res += NumMap[s[s.Length - 1]];
        }
       
        
        

        return res;


    }
    
    
    public string IntToRoman(int num)
    {
        string numStr = num.ToString();
        int bitNum = numStr.Length;
        string res = "";
        int divideNum = 1000; 
        //多少位
        while (num != 0)
        {
            int resNum = num / divideNum;
            
            if (resNum == 0)
            {
                divideNum /= 10;
                bitNum--;
            }
            else
            {
                int key = resNum * divideNum;
                if (CharMap.ContainsKey(key))
                {
                    res += CharMap[resNum * divideNum];
                }
                else
                {
                    if (resNum < 4)
                    {
                        for (int i = 0; i < resNum; i++)
                        {
                            res += CharMap[divideNum];
                        }
                    }
                    else
                    {
                        res += CharMap[5* divideNum];
                        for (int i = 5; i < resNum; i++)
                        {
                            res += CharMap[divideNum];
                        }
                    }
                    
                    
                }
                
                num = num % (divideNum * resNum);
                divideNum /= 10;
                bitNum--;
                
            }
            
        }

        return res;
    }
    
}