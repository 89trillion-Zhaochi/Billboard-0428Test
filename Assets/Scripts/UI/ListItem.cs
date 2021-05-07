using System.Collections.Generic;
using SuperScrollView;
using UnityEngine;
using UnityEngine.UI;
using ItemData = Data.ItemData;

// namespace UI
// {
    // public class ListItem : MonoBehaviour
    // {
    //     [SerializeField] private Image rank;  //rank照片
    //     [SerializeField] private Text rankText;
    //     [SerializeField] private Text nickName; //玩家昵称
    //     [SerializeField] private Text trophy;  //奖杯数
    //     [SerializeField] private Image status; //排名图标
    //     public Image[] mStarArray;
    //     [SerializeField] private List<Sprite> statusSprites;
    //     [SerializeField] private List<Sprite> rankSprites;
    //
    //     public GameObject mContentRootObj;
    //     int mItemDataIndex = -1;
    //     public LoopListView2 mLoopListView;
    //     
    //     public void Init()
    //     {
    //         for(int i = 0;i<mStarArray.Length;++i)
    //         {
    //             int index = i;
    //             ClickEventListener listener = ClickEventListener.Get(mStarArray[i].gameObject);
    //             listener.SetClickEventHandler(delegate (GameObject obj) { OnStarClicked(index); });
    //         }
    //         
    //     }
    //
    //     private void OnStarClicked(int index)
    //     {
    //         throw new System.NotImplementedException();
    //     }


        // private TestChildData childData;
        // public TestChildData ChildData
        // {
        //     get { return childData; }
        //     set
        //     {
        //         childData = value; //
        //         nickName.text = childData.Nickname;
        //         trophy.text = childData.Trophy.ToString();
        //         if (childData.RankNum < 3)
        //         {
        //             rank.sprite = rankSprites[childData.RankNum];
        //         }
        //         else
        //         {
        //             rank.gameObject.SetActive(false);
        //             rankText.text = (childData.RankNum + 1).ToString();
        //         }
        //         status.sprite = statusSprites[childData.StatusNum];
        //     }
        // }

    // }
//     public struct TestChildData
//     {
//         public string Nickname;
//         public int Trophy;
//         public int RankNum;
//         public int StatusNum;
//
//         public TestChildData(ItemData itemData,int i)
//         {
//             Nickname = itemData.nickName;
//             Trophy = itemData.trophy;
//             RankNum = i;
//             StatusNum = itemData.trophy/1000+1;
//         }
//     }
//
// }

namespace SuperScrollView
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
        
        
        public Text mNameText;
        public Image mIcon;
        public Image[] mStarArray;
        public Text mDescText;
        public Text mDescText2;
        public Color32 mRedStarColor = new Color32(249, 227, 101, 255);
        public Color32 mGrayStarColor = new Color32(215, 215, 215, 255);
        
        
        public GameObject mContentRootObj;
        int mItemDataIndex = -1;
        public LoopListView2 mLoopListView;
        public void Init()
        {
            for(int i = 0;i<mStarArray.Length;++i)
            {
                int index = i;
                ClickEventListener listener = ClickEventListener.Get(mStarArray[i].gameObject);
                listener.SetClickEventHandler(delegate (GameObject obj) { OnStarClicked(index); });
                
            }
            
        }

        void OnStarClicked(int index)
        {
            ItemData data = DataSourceMgr.Get.GetItemDataByIndex(mItemDataIndex);
            if(data == null)
            {
                return;
            }
            if(index == 0 && data.mStarCount == 1)
            {
                data.mStarCount = 0;
            }
            else
            {
                data.mStarCount = index + 1;
            }
            SetStarCount(data.mStarCount);
        }

        public void SetStarCount(int count)
        {
            int i = 0;
            for(; i<count;++i)
            {
                mStarArray[i].color = mRedStarColor;
            }
            for (; i < mStarArray.Length; ++i)
            {
                mStarArray[i].color = mGrayStarColor;
            }
        }

        public void SetItemData(int index)
        { 
            ItemData itemData = DataSourceMgr.Get.GetItemDataByIndex(index);
            nickName.text = itemData.nickName;
        trophy.text = itemData.trophy.ToString();
        if (itemData.rankNum < 3)
        {
            rank.sprite = rankSprites[itemData.rankNum];
        }
        else
        {
            rank.gameObject.SetActive(false);
            rankText.text = (itemData.rankNum + 1).ToString();
        }
        status.sprite = statusSprites[itemData.status];
        SetStarCount(itemData.mStarCount);
        }
        
    }
}
