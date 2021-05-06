//数据结构

namespace Data
{
    [System.Serializable]
    public class ItemData
    {
        public string uid;
        public string nickName;
        public int avatar;
        public int trophy;
        public string thirdAvatar;
        public int onlineStatus;
        public int role;
        public string abb;
    }
    [System.Serializable]
    public class BillBoardData
    {
        public int countDown;
        public ItemData[] list;
        public int dailyProductCountDown;
        public int seasonID;
        public int selfRank;
    }
}