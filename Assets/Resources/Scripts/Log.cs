using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Log : MonoBehaviour
{
    public string path;
    StreamWriter writer;
    private DateTime lastStart;

    public void Start()
    {
        writer = new StreamWriter(path, false);
    }

    public void OnDestroy()
    {
        writer.Close();
    }

    public void logStartWatch(Transform npc)
    {
        lastStart = DateTime.Now;
        writer.WriteLine(lastStart + " - Looking at " + npc.name);
    }

    public void logEndWatch(Transform npc)
    {
        DateTime now = DateTime.Now;
        writer.WriteLine(now + " - Looked at " + npc.name + " for " + (now - lastStart));
    }
}