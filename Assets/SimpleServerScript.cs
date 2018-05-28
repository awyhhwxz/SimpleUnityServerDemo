using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SimpleServerScript : MonoBehaviour {

    public string IP = "localhost";
    public string Port = "8765";
    public Text ReceiveDataTextUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendMessage()
    {
        StartCoroutine(Post());
    }

    IEnumerator Post()
    {
        var inData = new byte[] { 1, 2, 3 };
        WWW www = new WWW(string.Format("http://{0}:{1}", IP, Port), inData);
 
        yield return www;

        if (www.isDone)
        {
            if(www.error != null)
            {
                Debug.LogError(www.error);
            }
            var outData = www.bytes;
            PrintBytes(outData);
        }
    }

    private void PrintBytes(byte[] bytes)
    {
        StringBuilder sb = new StringBuilder();
        var splitChar = ',';
        foreach (var bt in bytes)
        {
            sb.Append(bt);
            sb.Append(splitChar);
        }
        ReceiveDataTextUI.text = sb.ToString().TrimEnd(splitChar);
    }
}
