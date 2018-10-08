using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Text;

public class Logger : MonoBehaviour {

    const int MAX_LOG_COUNT = 200;
    struct LogLine
    {
        public int Count;
        public string Log;
    }

    private LogLine lastLog = new LogLine()
    {
        Log = "",
        Count = 0
    };

    private string fixedLogText = "";

    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        Application.logMessageReceived += LogCallback;
    }

    private void LogCallback(string condition, string stackTrace, LogType type)
    {

        if (lastLog.Log == condition)
        {
            lastLog.Count++;
        }
        else
        {
            if (lastLog.Count == 0)
            {
                fixedLogText = lastLog.Log + "\n" + fixedLogText;
            }
            else
            {
                fixedLogText = lastLog.Log + " (" + lastLog.Count + ")\n" + fixedLogText;
            }

            lastLog = new LogLine()
            {
                Log = condition,
                Count = 0
            };
        }

        var next = (lastLog.Count == 0 ? lastLog.Log : lastLog.Log + "(" + lastLog.Count + ")") + "\n" + fixedLogText;
        textMeshPro.SetText(next);
    }
}
