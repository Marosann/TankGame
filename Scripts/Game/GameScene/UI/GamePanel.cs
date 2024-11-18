using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : BasePanel<GamePanel> 
{

    //����
    public CustomGUILabel labScore;
    //�r�g
    public CustomGUILabel labTime;
    //�ᥤ���˥�`
    public CustomGUIButton btnQuit;
    //�O��
    public CustomGUIButton btnSetting;
    //HP
    public CustomGUITexture texHP;
    //HP����
    public CustomGUITexture texMaxHP;
    //�F�r��ε���
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

            //Quit�ѥͥ���_��
            QuitPanel.Instance.ShowMe();
            Time.timeScale= 0;

        };



    }

    // Update is called once per frame
    void Update()
    {
        //�ե�`�ऴ�Ȥ˕r�g���ۼӤ���
        nowTime += Time.deltaTime;

         tempTime = (int)nowTime;
        labTime.content.text = "";

        if (tempTime / 3600 > 0)
        {
            labTime.content.text += tempTime / 3600 + "�r";
        }
        if (tempTime % 3600 / 60 > 0 || labTime.content.text != "")
        {
            labTime.content.text += tempTime % 3600 / 60 + "��";
        }

        labTime.content.text += tempTime % 60 + "��";



    }

    /// <summary>
    /// ����������API
    /// </summary>
    public void AddScore(int score)
    {

        nowScore += score;
        labScore.content.text= nowScore.ToString();

    }

    /// <summary>
    /// HP����API
    /// </summary>
    public void UpdateHP(int maxHP,int HP)
    {
        texHP.guiPos.width = (float)HP/maxHP *hpw;
    }
    /// <summary>
    /// maxHP������API
    /// </summary>
    public void UpdateMaxHP(int maxHP,int beforeMaxHP)
    {
        texMaxHP.guiPos.width = (float)maxHP / beforeMaxHP * hpw;
        hpw = texMaxHP.guiPos.width;
    }
}
