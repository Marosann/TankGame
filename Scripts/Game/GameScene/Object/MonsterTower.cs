using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //°k³h¤¹¤ë•régég¸ô
    public float fireTime = 1;
    //•rég¤òÓ›åh¤¹¤ë‰äÊý
    private float nowTime = 0;
    public Transform[] shootPos;
    public GameObject bulletObj;


    // Update is called once per frame
    void Update()
    {
        //•rég¤òÓ›åh¤·¡¢°k³h•rég¤Ë¤Ê¤Ã¤¿¤é°k³h¤¹¤ë
        nowTime += Time.deltaTime;
        if (nowTime >= fireTime)
        {   nowTime= 0; 
            Fire();
        }
    }
    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            
            GameObject obj  = Instantiate(bulletObj, shootPos[i].position, shootPos[i].rotation);
            BulletObj bullet = obj.GetComponent<BulletObj>();
            bullet.SetFather(this);


        }
    }

    public override void Wound(TankBaseObj tank)
    {
        //¥¿¥ï©`ÐÍ¤ÏŸo”³¤Ê¤Î¤Ç¡¢¥À¥á©`¥¸¤ÏÊ³¤ï¤Ê¤¤¡£
    }

}
