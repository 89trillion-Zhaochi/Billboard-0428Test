using System;
using Data;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
   
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform billboardTransform;
        [SerializeField] private RectTransform content;
        [SerializeField] private GameObject ItemPrefab;
        
        public Vector2 ItemRect { get { return new Vector2(968, 146); } }
        private void Start()
        {
            
        }

        public void SetContent(int length)
        {
            content.sizeDelta = new Vector2(ItemRect.x,length*ItemRect.y);
        }

        public void CreateItem()
        {
            //读取数据
            DSItemData dsItemData = new DSItemData();
            JsonDataManager.Instance.GetDataDSItem(ref dsItemData, "Json/data");
            
            int dataLength = dsItemData.list.Length; //获取json中的数据数量
            
            
            
        }
        public void CloseButtonOnClick()
        {
            Destroy(billboardTransform.gameObject);
        }

        
    }
}
