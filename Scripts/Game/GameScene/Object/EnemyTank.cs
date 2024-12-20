using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBaseObj
{


    
    //書�鬚�っている朕�傍惶�
    private Transform targetPos;
    //ランダムで聞う朕�傍惶�
    public Transform[] randomPos;


    public Transform lookAtTarget;

    public Transform[] shootPos;
    public GameObject bullets;

    public Texture maxHP;
    public Texture nowHP;

    private Rect maxHPRect;
    private Rect nowHPRect;
    //HPゲ�`ジの燕幣�r�g
    private float showTime;
   
    //�k�h����
    public float fireDis = 5;

    public float offsetTime = 1;

    private float nowTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        #region 2�w侭の�gに佩き栖する�I尖
        //朕�傍惶磴縫侫��`カス
        this.transform.LookAt(targetPos);
        //朕�傍惶磴墨鬚�う
        this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if (Vector3.Distance(this.transform.position,targetPos.position) < 0.05f)
        {
            RandomPos();
        }

        #endregion

        #region プレイヤ�`にフォ�`カスする�I尖


        if (lookAtTarget!= null)
        {
            tankHead.LookAt(lookAtTarget);
            //好�長��譴鉾襪辰討�たプレイヤ�`を�r�g�g侯のある好�弔鬚垢��I尖
            if (Vector3.Distance(this.transform.position,lookAtTarget.position)<= fireDis)
            {
                nowTime += Time.deltaTime;
                if (nowTime > offsetTime)
                {
                    nowTime = 0;

                    Fire();


                }


            }



        }



        #endregion

    }

    private void RandomPos()
    {
        if (randomPos.Length == 0) 
        {
            return;
        }

        targetPos = randomPos[Random.Range(0,randomPos.Length)];
    }
    public override void Fire()
    {

        for (int i = 0; i < shootPos.Length; i++)
        {
                GameObject obj = Instantiate(bullets,shootPos[i].position,shootPos[i].rotation);
                BulletObj bulletObj = obj.GetComponent<BulletObj>();
                
                bulletObj.SetFather(this);

        }

    }

    public override void Dead()
    {
        //enemy宜した瘁で泣方を貧げる�I尖
        GamePanel.Instance.AddScore(10);
        base.Dead();

    }

    // HPゲ�`ジの宙鮫�I尖
    private void OnGUI()
    {
        if (showTime >0)
        {
            showTime -= Time.deltaTime;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            maxHPRect.x = screenPos.x - 50;
            maxHPRect.y = screenPos.y - 50;
            maxHPRect.width = 100;
            maxHPRect.height = 15;
            GUI.DrawTexture(maxHPRect, maxHP);

            nowHPRect.x = screenPos.x - 50;
            nowHPRect.y = screenPos.y - 50;
            nowHPRect.width = (float)hp / maxHp * 100f;
            nowHPRect.height = 15;
            GUI.DrawTexture(nowHPRect, nowHP);


        }



    }

    public override void Wound(TankBaseObj tank)
    {
        base.Wound(tank);
        showTime = 5;
    }

}
