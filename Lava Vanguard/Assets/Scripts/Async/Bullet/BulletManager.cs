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
        public void GenerateBullet(CardRankData cardRankData)
        {
            if (cardRankData.CardID == "Card_01")
            {
                var bulletView = Instantiate(bulletPrefab, bulletContainer).GetComponent<BulletView>();
            }

        }
    }
}
