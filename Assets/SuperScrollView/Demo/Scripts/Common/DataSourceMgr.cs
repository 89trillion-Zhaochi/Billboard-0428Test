using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
namespace SuperScrollView
{

    public class ItemData
    {
        public string uid;
        public string nickName;
        public int trophy;
        public int status;
        public int rankNum;
        public bool mChecked;
        public bool mIsExpand;
        public int mStarCount;

    }
    
    public class DataSourceMgr : MonoBehaviour
    {

        List<ItemData> mItemDataList = new List<ItemData>();
        System.Action mOnRefreshFinished = null;
        System.Action mOnLoadMoreFinished = null;
        int mLoadMoreCount = 7;
        float mDataLoadLeftTime = 0;
        float mDataRefreshLeftTime = 0;
        bool mIsWaittingRefreshData = false;
        bool mIsWaitLoadingMoreData = false;
        public int mTotalDataCount = 42;
        private BillBoardData _data;
        private BillBoardData _billBoardData;

        static DataSourceMgr instance = null;

        public static DataSourceMgr Get
        {
            get
            {
                if (instance == null)
                {
                    instance = Object.FindObjectOfType<DataSourceMgr>();
                }
                return instance;
            }

        }

        void Awake()
        {
            Init();
        }


        public void Init()
        {
            JsonDataManager.Instance.GetDataDSItem(ref _billBoardData, "Json/ranklist");
            DoRefreshDataSource();
        }

        public ItemData GetItemDataByIndex(int index)
        {
            if (index < 0 || index >= mItemDataList.Count)
            {
                return null;
            }
            return mItemDataList[index];
        }

        public ItemData GetItemDataById(int itemId)
        {
            int count = mItemDataList.Count;
            return mItemDataList[itemId];
        }

        public int TotalItemCount
        {
            get
            {
                return mItemDataList.Count;
            }
        }

        public void RequestRefreshDataList(System.Action onReflushFinished)
        {
            mDataRefreshLeftTime = 1;
            mOnRefreshFinished = onReflushFinished;
            mIsWaittingRefreshData = true;
        }

        public void RequestLoadMoreDataList(int loadCount,System.Action onLoadMoreFinished)
        {
            mLoadMoreCount = loadCount;
            mDataLoadLeftTime = 1;
            mOnLoadMoreFinished = onLoadMoreFinished;
            mIsWaitLoadingMoreData = true;
        }

        public void Update()
        {
            if (mIsWaittingRefreshData)
            {
                mDataRefreshLeftTime -= Time.deltaTime;
                if (mDataRefreshLeftTime <= 0)
                {
                    mIsWaittingRefreshData = false;
                    DoRefreshDataSource();
                    if (mOnRefreshFinished != null)
                    {
                        mOnRefreshFinished();
                    }
                }
            }
            if (mIsWaitLoadingMoreData)
            {
                mDataLoadLeftTime -= Time.deltaTime;
                if (mDataLoadLeftTime <= 0)
                {
                    mIsWaitLoadingMoreData = false;
                    DoLoadMoreDataSource();
                    if (mOnLoadMoreFinished != null)
                    {
                        mOnLoadMoreFinished();
                    }
                }
            }

        }

        public void SetDataTotalCount(int count)
        {
            mTotalDataCount = count;
            DoRefreshDataSource();
        }

        public void ExchangeData(int index1,int index2)
        {
            ItemData tData1 = mItemDataList[index1];
            ItemData tData2 = mItemDataList[index2];
            mItemDataList[index1] = tData2;
            mItemDataList[index2] = tData1;
        }

        public void RemoveData(int index)
        {
            mItemDataList.RemoveAt(index);
        }

        public void InsertData(int index,ItemData data)
        {
            mItemDataList.Insert(index,data);
        }

        void DoRefreshDataSource()
        {
            mItemDataList.Clear();
            for (int i = 0; i < mTotalDataCount; ++i)
            {
                ItemData tData = new ItemData();
                tData.uid = _billBoardData.list[i].uid;
                tData.nickName = _billBoardData.list[i].nickName;
                tData.trophy = _billBoardData.list[i].trophy;
                tData.rankNum = i;
                tData.status = _billBoardData.list[i].trophy/1000+1;
                tData.mChecked = false;
                tData.mIsExpand = false;
                mItemDataList.Add(tData);
            }
        }

        void DoLoadMoreDataSource()
        {
            int count = mItemDataList.Count;
            for (int k = 0; k < mLoadMoreCount; ++k)
            {
                int i = k + count;
                ItemData tData = new ItemData();
                tData.uid = _billBoardData.list[i].uid;
                tData.nickName = _billBoardData.list[i].nickName;
                tData.trophy = _billBoardData.list[i].trophy;
                tData.rankNum = i;
                tData.status = _billBoardData.list[i].trophy/1000+1;
                tData.mChecked = false;
                tData.mIsExpand = false;
                mItemDataList.Add(tData);
            }
            mTotalDataCount = mItemDataList.Count;
        }

        public void CheckAllItem()
        {
            int count = mItemDataList.Count;
            for (int i = 0; i < count; ++i)
            {
                mItemDataList[i].mChecked = true;
            }
        }

        public void UnCheckAllItem()
        {
            int count = mItemDataList.Count;
            for (int i = 0; i < count; ++i)
            {
                mItemDataList[i].mChecked = false;
            }
        }

        public bool DeleteAllCheckedItem()
        {
            int oldCount = mItemDataList.Count;
            mItemDataList.RemoveAll(it => it.mChecked);
            return (oldCount != mItemDataList.Count);
        }

    }

}