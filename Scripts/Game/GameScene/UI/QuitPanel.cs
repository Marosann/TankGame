using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitPanel : BasePanel<QuitPanel>
{

    public CustomGUIButton btnClose;
    public CustomGUIButton btnQuitY;
    public CustomGUIButton btnQuitN;
    



    // Start is called before the first frame update
    void Start()
    {
       


        btnClose.clickEvent += () =>
        {
           HideMe();
        };

        btnQuitN.clickEvent += () => 
        {
            HideMe();

        };

        btnQuitY.clickEvent += () =>
        {

            //�ᥤ���˥�`�ˑ���
            SceneManager.LoadScene("BeginScene");
        
        
        };


        HideMe();


    }



    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
