using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetNickNameView : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inNickName;
    [SerializeField]
    Button btnSetNickName;

    void Awake()
    {
        btnSetNickName.onClick.AddListener(ClickSetNickName);
    }

    bool NickNameEmpty => string.IsNullOrEmpty(inNickName.text);

    string NickName => inNickName.text;

    void ClickSetNickName()
    {
        if(NickNameEmpty) return;
        Launcher.instance.SetNickName(NickName);
    }
}
