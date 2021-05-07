using UnityEngine;

namespace UI
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform rootTs;
        [SerializeField] private GameObject billboardPrefab;
        
        /// <summary>
        /// root页面的单击事件
        /// </summary>
        public void OpenButtonOnClick()
        {
            var chest = Instantiate(billboardPrefab, rootTs);
            chest.name = "Biliboard";
            chest.transform.localScale = Vector3.one;
            chest.transform.localPosition = Vector3.zero;
        }
    }
}
