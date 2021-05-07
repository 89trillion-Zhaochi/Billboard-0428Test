using System.Collections.Generic;
using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ListItem : MonoBehaviour
    {
        [SerializeField] private Image rank; //rank照片
        [SerializeField] private Text rankText;
        [SerializeField] private Text nickName; //玩家昵称
        [SerializeField] private Text trophy; //奖杯数
        [SerializeField] private Image status; //排名图标
        [SerializeField] private List<Sprite> statusSprites;
        [SerializeField] private List<Sprite> rankSprites;
        private string uid;

        public void Click()
        {
            Toast.Instance.ShowToast($"User: {uid}, Rank: {rankText.text}");
        }
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