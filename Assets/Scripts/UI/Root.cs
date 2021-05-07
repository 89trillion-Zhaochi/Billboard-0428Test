using UnityEngine;

namespace UI
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform rootTs;
        [SerializeField] private GameObject billboardPrefab;
        
        //点击Root按钮事件
        public void OpenButtonOnClick()
        {
            var chest = Instantiate(billboardPrefab, rootTs);
            chest.name = "Biliboard";
            chest.transform.localScale = Vector3.one;
            chest.transform.localPosition = Vector3.zero;
        }
    }
}
