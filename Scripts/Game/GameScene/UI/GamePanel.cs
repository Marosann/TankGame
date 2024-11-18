using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel> 
{

    //点数
    public CustomGUILabel labScore;
    //時間
    public CustomGUILabel labTime;
    //メインメニュー
    public CustomGUIButton btnQuit;
    //設定
    public CustomGUIButton btnSetting;
    //HP
    public CustomGUITexture texHP;
    //HP上限
    public CustomGUITexture texMaxHP;
    //現時点の点数
    [HideInInspector]
    public int nowScore;
    [HideInInspector]
    public float nowTime;

    public float hpw = 350;

    private int tempTime;

    // Start is called before the first frame update
    void Start()
    {
       

        btnSetting.clickEvent += () =>
        {
            SettingPanel.Instance.ShowMe();
            Time.timeScale = 0;
        };


        btnQuit.clickEvent += () => 
        {

            //Quitパネルを開く
            QuitPanel.Instance.ShowMe();
            Time.timeScale= 0;

        };



    }

    // Update is called once per frame
    void Update()
    {
        //フレームごとに時間を累加する
        nowTime += Time.deltaTime;

         tempTime = (int)nowTime;
        labTime.content.text = "";

        if (tempTime / 3600 > 0)
        {
            labTime.content.text += tempTime / 3600 + "時";
        }
        if (tempTime % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += tempTime % 3600 / 60 + "分";
        }

        labTime.content.text += tempTime % 60 + "秒";



    }

    /// <summary>
    /// 点数増加用API
    /// </summary>
    public void AddScore(int score)
    {

        nowScore += score;
        labScore.content.text= nowScore.ToString();

    }

    /// <summary>
    /// HP更新API
    /// </summary>
    public void UpdateHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP/maxHP *hpw;
    }
    /// <summary>
    /// maxHP更新用API
    /// </summary>
    public void UpdateMaxHP(int maxHP,int beforeMaxHP)
    {
        texMaxHP.guiPos.width = (float)maxHP / beforeMaxHP * hpw;
        hpw = texMaxHP.guiPos.width;
    }
}
