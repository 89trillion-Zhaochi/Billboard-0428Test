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

        public void Content()
        {
            
        }
        public void CloseButtonOnClick()
        {
            Destroy(billboardTransform.gameObject);
        }

        
    }
}