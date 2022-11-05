using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class end_stats : MonoBehaviour
{
    TextMeshProUGUI time_text;
    TextMeshProUGUI death_text;
    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        string minutes = Mathf.Floor(static_variable.time_played / 60).ToString("00");
        string seconds = (static_variable.time_played % 60).ToString("00");
        time_text = gameObject.transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        death_text = gameObject.transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();      
        time_text.SetText(string.Format("Tempo: {0}:{1}", minutes,seconds));
        death_text.SetText("Mortes:{0}", static_variable.times_ded);
        
    }
}
