using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CubeObj : MonoBehaviour
{
    public GameObject[] rewardObj;
    public GameObject cubeEff;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //ランダムでアイテムが鯛ちる
            int rangeInt = Random.Range(0, 99);
            //50%の�_楕
            if (rangeInt<50)
            {
                rangeInt = Random.Range(0,rewardObj.Length);
                Instantiate(rewardObj[rangeInt],this.transform.position,this.transform.rotation);
            }



            Destroy(gameObject);

            //�欧譴吹瓩離┘侫Д�トを壅伏
            GameObject eff = Instantiate(cubeEff, this.transform.position, this.transform.rotation);

            AudioSource audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isOpenSound;

        }
    }



}
