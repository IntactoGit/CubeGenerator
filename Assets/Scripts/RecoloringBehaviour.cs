using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RecoloringBehavi : MonoBehaviour
{
    [SerializeField] private float _recoloringDuration = 1f;
    
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    private float _recoloringTime;

    [SerializeField]
    private float _delay = 2f;
    private float _timer = 0f;
    
    private void Awake()
    {
        
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
        
    }

    

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);

    }

     
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _delay)
        {
            GenerateNextColor();
            Debug.Log(_timer);
            _timer = 0f;
            _recoloringTime = 0f;
        }
        
        
        _recoloringTime += Time.deltaTime;
        var progress = _recoloringTime / _recoloringDuration;
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;
        
    }

    



}
