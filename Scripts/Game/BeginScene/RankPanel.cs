using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    //項目が多いため、コードで連携する
  
    private List<CustomGUILabel> labPL = new List<CustomGUILabel>();
    private List<CustomGUILabel> labSC = new List<CustomGUILabel>();
    private List<CustomGUILabel> labTE = new List<CustomGUILabel>();



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
           
            labPL.Add(this.transform.Find("Player/LabelPL" + i).GetComponent<CustomGUILabel>());
            labSC.Add(this.transform.Find("Score/LabelSC" + i).GetComponent<CustomGUILabel>());
            labTE.Add(this.transform.Find("Time/LabelTE" + i).GetComponent<CustomGUILabel>());
        }

        btnClose.clickEvent+= () =>
        {
            HideMe();
            BeginPanel.Instance.ShowMe();
        };

        //テスト用
        //GameDataMgr.Instance.AddRankInfo("test", 100, 6790);


        HideMe ();
    }


    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }

    public void UpdatePanelInfo()
    {

        
        List<RankInfo> list = GameDataMgr.Instance.rankData.list;
        //保存されたデータをパネルに更新
        for (int i = 0; i < list.Count; i++)
        {   
            //名前
            labPL[i].content.text = list[i].name;
            //スコア
            labSC[i].content.text = list[i].score.ToString();
            //時間をxxx時xx分xx秒に変える
            int time = (int)list[i].time;
            labTE[i].content.text = "";
            if (time/3600 > 0)
            {
                labTE[i].content.text += time / 3600 + "時"; 
            }
            if (time %3600 / 60 >  0 || labTE[i].content.text != "")
            {
                labTE[i].content.text += time % 3600 / 60 + "分";
            }

            labTE[i].content.text += time % 60 + "秒";



        }

    }
}
