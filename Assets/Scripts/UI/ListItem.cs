using System.Collections.Generic;
using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ListItem : MonoBehaviour
    {
        [SerializeField] private Image rank; //rank照片
        [SerializeField] private Text rankText; //rank数字
        [SerializeField] private Text nickName; //玩家昵称
        [SerializeField] private Text trophy; //奖杯数
        [SerializeField] private Image status; //排名图标
        [SerializeField] private List<Sprite> statusSprites; //等级sprites list
        [SerializeField] private List<Sprite> rankSprites; //rank的sprites list
        private string uid;

        /// <summary>
        /// 单击item之后的toast展示
        /// </summary>
        public void Click()
        {
            Toast.Instance.ShowToast($"User: {uid}, Rank: {rankText.text}");
        }
        
        /// <summary>
        /// 根据传入数据来初始化item
        /// </summary>
        public void SetItemData(int index)
        {
            
            ItemData itemData = DataSourceMgr.Get.GetItemDataByIndex(index);
            uid = itemData.uid;
            nickName.text = itemData.nickName;
            trophy.text = itemData.trophy.ToString();
            rankText.text = (itemData.rankNum + 1).ToString();
            if (itemData.rankNum < 3)
            {
                rank.gameObject.SetActive(true);
                rank.sprite = rankSprites[itemData.rankNum];
            }
            else
            {
                rank.gameObject.SetActive(false);
            }

            status.sprite = statusSprites[itemData.status];
        }
    }
}