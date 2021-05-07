using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CountDown : MonoBehaviour
    {
        public Text text;
        public int totalTime = 835503;
        private int _day;
        private int _hour;
        private int _minute;
        private int _second;

        private IEnumerator Start()
        {
            yield return StartCoroutine(TimeCountDown());
        }

        private IEnumerator TimeCountDown()
        {
        
            while (totalTime >= 0)
            {
                _day = totalTime / 34560;
                _hour = (totalTime % 34560) / 3600;
                _minute = (totalTime - _day * 34560 - _hour * 3600)/60;
                _second = totalTime - _day * 34560 - _hour * 3600 - _minute * 60;
                text.text = "Ends in:  " + _day + "d  " + _hour + "h  " + _minute + "m  " + _second + "s";
                yield return new WaitForSeconds(1);
                totalTime--;
            }
            yield return null;
        }
    }
}