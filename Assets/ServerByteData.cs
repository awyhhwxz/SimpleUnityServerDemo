using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ServerByteData : IData {
    
    byte[] _inData = new byte[] { 1, 2, 3 };

    public byte[] GetInData()
    {
        return _inData;
    }

    public string FormatReceiveData(byte[] datas)
    {
        StringBuilder sb = new StringBuilder();
        var splitChar = ',';
        foreach (var bt in datas)
        {
            sb.Append(bt);
            sb.Append(splitChar);
        }
        return sb.ToString().TrimEnd(splitChar);
    }
}
