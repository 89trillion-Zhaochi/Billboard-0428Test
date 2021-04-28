using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Image rank;
        [SerializeField] private Text nickName;
        [SerializeField] private Text trophy;
        [SerializeField] private Image status;

        [SerializeField] private List<Sprite> statusSprites;
        [SerializeField] private List<Sprite> rankSprites;
    }
}
