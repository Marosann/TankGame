using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTower : TankBaseObj
{
    //�k�h����r�g�g��
    public float fireTime = 1;
    //�r�g��ӛ�h�������
    private float nowTime = 0;
    public Transform[] shootPos;
    public GameObject bulletObj;


    // Update is called once per frame
    void Update()
    {
        //�r�g��ӛ�h�����k�h�r�g�ˤʤä���k�h����
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
        //����`�ͤϟo���ʤΤǡ�����`����ʳ��ʤ���
    }

}
