using System.Collections.Generic;
using Data;
using SuperScrollView;
using UnityEngine;

namespace UI
{
    public class Billboard : MonoBehaviour
    {
        public LoopListView2 mLoopListView;
        
        private BillBoardData _data;
        private BillBoardData _billBoardData;
        private bool _itemIsOpen;
        private List<CustomData> _mDataList = null;
        [SerializeField] private Transform billboardTransform;
        
        public void CreateItem()
        {
            if (_itemIsOpen == false)
            {
                //读取数据
                JsonDataManager.Instance.GetDataDSItem(ref _billBoardData, "Json/ranklist");
                mLoopListView.InitListView(_billBoardData.list.Length,OnGetItemByIndex);
                _itemIsOpen = true;
            }
            else
            {
                Debug.Log("LoopListView2.InitListView method can be called only once.");
            }
        }

        public void CloseItem()
        {
            
            _itemIsOpen = false;
            CloseButtonOnClick();
            // _billBoardData.list.
            mLoopListView.RefreshAllShownItem();
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
            Debug.Log(index);
            ListItem listItem = item.GetComponent<ListItem>();
            if (item.IsInitHandlerCalled == false)
            {
                item.IsInitHandlerCalled = true;
            }
            listItem.SetItemData(index);
            return item;
        }
    }
}
