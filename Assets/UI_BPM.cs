using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BPM : MonoBehaviour
{
    Text _text;
    public BPM _bpmObject;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "BPM: " + _bpmObject._bpm.ToString();
    }
}
