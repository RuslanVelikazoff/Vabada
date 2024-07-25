using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI timerText;

    private int minute;
    private float seconds;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        seconds += Time.deltaTime;

        if (seconds >= 60)
        {
            seconds = 0;
            minute++;
        }

        timerText.text = GetTimerString();
    }

    public string GetTimerString()
    {
        string minuteText = "";
        string secondsText = "";

        if (minute < 10)
        {
            minuteText = "0" + minute;
        }
        else
        {
            minuteText = minute.ToString();
        }

        if (seconds < 10)
        {
            secondsText = "0" + (int)seconds;
        }
        else
        {
            secondsText = ((int)seconds).ToString();
        }

        string result = minuteText + ":" + secondsText;

        return result;
    }
}
