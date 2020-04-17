using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tapping_UI : MonoBehaviour
{
    private Transform _UI;
    private Image[] _tapImage;
    public Sprite _iconTapOpen, _iconTapClose;
    // Start is called before the first frame update
    void Start()
    {
        _UI = transform.GetChild(0);
        _UI.gameObject.SetActive(false);
        _tapImage = new Image[4];
        for(int i=0; i< _tapImage.Length; i++)
        {
            _tapImage[i] = _UI.GetChild(i).GetComponent<Image>();
            _tapImage[i].sprite = _iconTapOpen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BPM._customBeat)
        {
            _UI.gameObject.SetActive(true);
            for(int i = 0; i< _tapImage.Length; i++)
            {
                if(i < BPM._tap)
                {
                    _tapImage[i].sprite = _iconTapClose;
                }
                else
                {
                    _tapImage[i].sprite = _iconTapOpen;
                }
            }
        }
        else
        {
            _UI.gameObject.SetActive(false);
        }
    }
}
