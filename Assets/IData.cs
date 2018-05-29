using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData {

    byte[] GetInData();

    string FormatReceiveData(byte[] datas);
}
