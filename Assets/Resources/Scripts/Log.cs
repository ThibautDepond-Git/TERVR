using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Log : MonoBehaviour
{
    public string path;
    StreamWriter interactionLogWriter;
    StreamWriter playerHeadMotionLogWriter;
    private DateTime lastStart;

    public void Start()
    {
        interactionLogWriter = new StreamWriter(path+"/interactionLog.txt", false);
        interactionLogWriter.WriteLine(DateTime.Now + " - [SYSTEM] - start");

        playerHeadMotionLogWriter = new StreamWriter(path+"/headMotionLog.csv", false);
        playerHeadMotionLogWriter.WriteLine("degree_X_[up-down];degree_Y_[left-right]");
    }

    public void OnDestroy()
    {
        interactionLogWriter.WriteLine(DateTime.Now + " - [SYSTEM] - end");

        interactionLogWriter.Close();
        playerHeadMotionLogWriter.Close();
    }

    public void logStartWatch(Transform npc)
    {
        lastStart = DateTime.Now;
        interactionLogWriter.WriteLine(lastStart + " - [PLAYER] - Looking at " + npc.name);
    }

    public void logEndWatch(Transform npc)
    {
        DateTime now = DateTime.Now;
        interactionLogWriter.WriteLine(now + " - [PLAYER] - Looked at " + npc.name + " for " + (now - lastStart));
    }

    public void logHeadMotion(Transform player)
    {
        playerHeadMotionLogWriter.WriteLine(normalizeAngles(player.rotation.eulerAngles.x) + ";" + normalizeAngles(player.rotation.eulerAngles.y));
    }

    String normalizeAngles(float angle)
    {
        if (angle > 180)
        {
            float newAngle = angle - 360;
            return newAngle.ToString();
        }
        return angle.ToString();
    }

    public void logPressedButton(String button)
    {
        interactionLogWriter.WriteLine(DateTime.Now + " - [MENU] - Button : " + button + " has been pressed");
    }

    public void log(String msg)
    {
        interactionLogWriter.WriteLine(DateTime.Now + msg);
    }
}