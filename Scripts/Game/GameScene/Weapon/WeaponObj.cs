using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObj : MonoBehaviour
{


    public GameObject bullet;

    public Transform[] shootPos;
    //�h������Ф��륿��
    public TankBaseObj fatherTank;

    //�h�����Х��󥯤��O��
    public void SetFather(TankBaseObj obj)
    {
        fatherTank = obj;   
    }



    public void Fire()
    {
        //�k�h����Ȥ���ˡ��h���Υ��󥹥��󥹤����롣
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);

            BulletObj bulletObj = obj.GetComponent<BulletObj>();
            bulletObj.SetFather(fatherTank); 
        }
    }


}
