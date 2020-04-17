using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOnBeat : MonoBehaviour
{
    [Header("Behaaviour Settings")]
    public Transform _target;
    private MeshRenderer _meshRenderer;
    public Material _material;
    private Material _materialInstance;
    public Color _color;
    public string _colorProperty;

    private float _strength;
    [Range(0.8f,0.99f)]
    public float _fallbackFactor;
    [Range(1,4)]
    public float _colorMultiplier;

    [Header("Beat Settings")]
    [Range(0, 3)]
    public int _onFullBeat;
    [Range(0, 7)]
    public int[] _onBeatD8;
    private int _beatCountFull;

    // Start is called before the first frame update
    void Start()
    {
        if(_target != null)
        {
            _meshRenderer = _target.GetComponent<MeshRenderer>();
        }
        else
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
        _strength = 0;
        _materialInstance = new Material(_material);
        _materialInstance.EnableKeyword("_EMISSION");
        _meshRenderer.material = _materialInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if(_strength > 0)
        {
            _strength *= _fallbackFactor;
        }
        else
        {
            _strength = 0;
        }
        CheckBeat();
        _materialInstance.SetColor(_colorProperty, _color * _strength * _colorMultiplier);
    }

    void Colorize()
    {
        _strength = 1;
    }

    void CheckBeat()
    {
        _beatCountFull = BPM._beatCountFull % 4;
        for (int i = 0; i < _onBeatD8.Length; i++)
        {
            if (BPM._beatD8 && _beatCountFull == _onFullBeat && BPM._beatCountD8 % 8 == _onBeatD8[i])
            {
                Colorize();
            }
        }
    }
}
