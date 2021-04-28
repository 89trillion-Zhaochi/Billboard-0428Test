using Base;
using UnityEngine;

//使用单例模式将读取的变量作为全局变量使用，提高访问速度
namespace Data
{
    public class JsonDataManager:Singleton<JsonDataManager>//负责解析
    {
        public void GetDataDSItem(ref DSItemData dsItemData,string jsonpath)//读取MyData类型的数据
        {
            var dailySelectionItemJsonTextAsset = Resources.Load(jsonpath) as TextAsset;
            if (!(dailySelectionItemJsonTextAsset is null))
            {
                dsItemData = JsonUtility.FromJson<DSItemData>(dailySelectionItemJsonTextAsset.text);

            }
        }
    }
}