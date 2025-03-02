using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Async
{
    public class BulletManager : MonoBehaviour
    {
        public static BulletManager Instance {  get; private set; }
        public GameObject bulletPrefab;
        public Transform bulletContainer;
        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// Just temp code!!!!!!!!!!!!!!!!!! 
        /// </summary>
        /// <param name="cardRankData"></param>
        public void GenerateBullet(CardRankData cardRankData)
        {
            if (cardRankData.CardID == "Card_01")
            {
                var bulletView = Instantiate(bulletPrefab, PlayerManager.Instance.playerView.transform.position, Quaternion.identity, bulletContainer).GetComponent<BulletView>();  //ugly
                var way = PlayerManager.Instance.playerView.transform.localScale.x; //ugly
                if (way > 0)
                    bulletView.speed = 10;
                else
                    bulletView.speed = 10;
            }

        }
    }
}
