using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Хǩ`��
/// </summary>
public class RankInfo 
{

    public string name;
    public int score;
    public float time;


    public RankInfo()
    {

    }


    
    public RankInfo(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }







}



/// <summary>
/// ȫ��󥯥ǩ`��
/// </summary>
public class RankList
{
    public List<RankInfo> list;
}