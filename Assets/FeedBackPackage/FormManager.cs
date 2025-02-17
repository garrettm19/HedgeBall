﻿using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FormManager : MonoBehaviour
{
    [SerializeField] private Survey survey;
    [SerializeField] private GameObject submitButton;
    [SerializeField] private string feedBack1;

    //Add the string data from google form here
    private const string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSetVkjQxniuitRTHb22Z4nNQJEmVkCFskVNvhOssv1Z_g2ouw/formResponse";
    private const string entry = "entry.1056770302";

    public void Send()
    {
        feedBack1 = survey.myResults;
        StartCoroutine(Post(feedBack1));
    }

    private IEnumerator Post(string string_1)
    {
        WWWForm form = new WWWForm();
        form.AddField(entry, string_1);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
    }    
}