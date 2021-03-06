using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float typeSpeed = 5f;

    public bool IsTyping { get; private set; }

    private TMP_Text _textLabel;
    private string _textToType;

    private AudioSource _audioSource;

    public void Run(string textToType, TMP_Text textLabel)
    {
        _textToType = textToType;
        _textLabel = textLabel;

        StartCoroutine(TypeTextCoRoutine());
    }

    public void Run(string textToType, TMP_Text textLabel, AudioSource audioSource)
    {
        _textToType = textToType;
        _textLabel = textLabel;
        _audioSource = audioSource;
        
        StartCoroutine(TypeTextCoRoutine());
    }

    
    public void FinishTyping()
    {
        if (_audioSource != null && _audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
        
        StopAllCoroutines();
        IsTyping = false;
        _textLabel.text = _textToType;

    }

    private IEnumerator TypeTextCoRoutine()
    {
        IsTyping = true;
        _textLabel.text = string.Empty;
        float t = 0;
        int charIndex = 0;

        if (_audioSource != null)
        {
            _audioSource.Play();
        }

        while (charIndex < _textToType.Length)
        {
              
            t += Time.deltaTime * typeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, _textToType.Length);

            _textLabel.text = _textToType.Substring(0, charIndex);

            yield return null;
        }

        if (_audioSource != null)
        {
            _audioSource.Stop();
        }

        IsTyping = false;
        _textLabel.text = _textToType;

    }
}
