using System.Collections.Generic;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ListItem : MonoBehaviour
    {
        [SerializeField] private Image rank;  //rank照片
        [SerializeField] private Text rankText;
        [SerializeField] private Text nickName; //玩家昵称
        [SerializeField] private Text trophy;  //奖杯数
        [SerializeField] private Image status; //排名图标

        [SerializeField] private List<Sprite> statusSprites;
        [SerializeField] private List<Sprite> rankSprites;


        private TestChildData childData;
        public TestChildData ChildData
        {
            get { return childData; }
            set
            {
                childData = value; //
                nickName.text = childData.Nickname;
                trophy.text = childData.Trophy.ToString();
                if (childData.RankNum < 3)
                {
                    rank.sprite = rankSprites[childData.RankNum];
                }
                else
                {
                    rank.gameObject.SetActive(false);
                    rankText.text = (childData.RankNum + 1).ToString();
                }
                status.sprite = statusSprites[childData.StatusNum];
            }
        }

    }
    public struct TestChildData
    {
        public string Nickname;
        public int Trophy;
        public int RankNum;
        public int StatusNum;

        public TestChildData(ItemData itemData,int i)
        {
            Nickname = itemData.nickName;
            Trophy = itemData.trophy;
            RankNum = i;
            StatusNum = itemData.trophy/1000+1;
        }
    }

}
