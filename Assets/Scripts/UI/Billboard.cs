using System.Collections.Generic;
using Data;
using SuperScrollView;
using UnityEngine;

namespace UI
{
   
    class CustomData
    {
        public string mContent;
    }
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform billboardTransform;
        [SerializeField] private RectTransform content;
        public LoopListView2 mLoopListView;
        //从这开始写更新列表的部分
        private BillBoardData _data;
        private BillBoardData _billBoardData;
        private bool _itemIsOpen = false; 
        
        List<CustomData> mDataList = null;

        public Vector2 ItemRect => new Vector2(968, 146);

        public void SetContent(int length)
        {
            content.sizeDelta = new Vector2(ItemRect.x,length*ItemRect.y);
        }
       
        public void CreateItem()
        {
            if (_itemIsOpen == false)
            {
                //读取数据
                JsonDataManager.Instance.GetDataDSItem(ref _billBoardData, "Json/ranklist");
                mLoopListView.InitListView(_billBoardData.list.Length,OnGetItemByIndex);
                _itemIsOpen = true;
            }
           
            
        }

        public void CloseItem()
        {
            _itemIsOpen = false;
            mLoopListView
        }
        public void CloseButtonOnClick()
        {
            Destroy(billboardTransform.gameObject);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
        {
            if (index < 0 || index >= _billBoardData.list.Length)
            {
                return null;
            }
            LoopListViewItem2 item = listView.NewListViewItem("Item");
            ListItem listItem = item.GetComponent<ListItem>();
            if (item.IsInitHandlerCalled == false)
            {
                item.IsInitHandlerCalled = true;
                listItem.ChildData = new TestChildData(_billBoardData.list[index%42], index%42);
            }
            return item;
        }
    }
}
