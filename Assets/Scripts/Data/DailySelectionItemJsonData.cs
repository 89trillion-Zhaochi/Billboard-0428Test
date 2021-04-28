//数据结构

namespace Data
{
    [System.Serializable]
    public class DailyProduct
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
    public class DSItemData
    {
        public int countDown;
        public DailyProduct[] list;
        public int dailyProductCountDown;
        public int seasonID;
        public int selfRank;
    }
}