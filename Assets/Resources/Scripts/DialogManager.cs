using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    bool playing;
    Queue<String> queue;
    public GameObject[] from;

    public void Start()
    {
        queue = new Queue<String>();
        playing = false;
    }

    public void StartDialog()
    {
        //TODO interrompre dialogue en cours
        if (playing) return;

        queue.Clear();
        queue.Enqueue("dialogue_test_1");
        queue.Enqueue("dialogue_test_2");
        queue.Enqueue("dialogue_test_3");
        queue.Enqueue("dialogue_test_4");

        playing = true;
        PlayNext();
    }

    private void PlayNext()
    {
        float time = FindObjectOfType<AudioManager>().PlayFrom(queue.Dequeue(), from[1]);
        StartCoroutine(WaitForNext(time));
    }

    IEnumerator WaitForNext(float time)
    {
        yield return new WaitForSeconds(time);
        if (playing)
        {
            if (queue.Count > 0) PlayNext();
            else playing = false;
        }
    }
}
