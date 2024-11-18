using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public CustomGUIButton btnClose;

    //�Ŀ���त���ᡢ���`�ɤ��BЯ����
  
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

        //�ƥ�����
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
        //���椵�줿�ǩ`����ѥͥ�˸���
        for (int i = 0; i < list.Count; i++)
        {   
            //��ǰ
            labPL[i].content.text = list[i].name;
            //������
            labSC[i].content.text = list[i].score.ToString();
            //�r�g��xxx�rxx��xx��ˉ䤨��
            int time = (int)list[i].time;
            labTE[i].content.text = "";
            if (time/3600 > 0)
            {
                labTE[i].content.text += time / 3600 + "�r"; 
            }
            if (time %3600 / 60 >  0 || labTE[i].content.text != "")
            {
                labTE[i].content.text += time % 3600 / 60 + "��";
            }

            labTE[i].content.text += time % 60 + "��";



        }

    }
}
