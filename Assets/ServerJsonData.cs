using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerJsonData : IData
{
    private GameObject _inputUIRoot = null;
    private InputField _stringValueInput = null;
    private InputField _intValueInput = null;
    private Toggle _boolToggle = null;

    private ServerTransferInfo _info = new ServerTransferInfo();

    protected void RefreshInputUI()
    {
        if(_inputUIRoot == null)
        {
            _inputUIRoot = GameObject.Find("Canvas/InputRoot/Layout");
            if(_inputUIRoot != null)
            {
                _stringValueInput = _inputUIRoot.transform.Find("StringValInput").GetComponent<InputField>();
                _intValueInput = _inputUIRoot.transform.Find("IntValInput").GetComponent<InputField>();
                _boolToggle = _inputUIRoot.transform.Find("BoolValToggle").GetComponent<Toggle>();
            }
        }
    }

    public string FormatReceiveData(byte[] datas)
    {
        var jsonString = System.Text.Encoding.UTF8.GetString(datas);
        _info = LitJson.JsonMapper.ToObject<ServerTransferInfo>(jsonString);
        return string.Format("Via server transfer, \nstring value is {0}, \nint value is {1}, \nbool value is {2}", _info.StringValue, _info.IntValue, _info.BoolValue);
    }

    public byte[] GetInData()
    {
        RefreshInputUI();
        _info.StringValue = _stringValueInput.text;
        _info.IntValue = int.Parse(_intValueInput.text);
        _info.BoolValue = _boolToggle.isOn;

        var json = LitJson.JsonMapper.ToJson(_info);
        return System.Text.Encoding.UTF8.GetBytes(json);
    }
}
