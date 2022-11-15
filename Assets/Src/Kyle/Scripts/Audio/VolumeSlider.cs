using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSlider : MonoBehaviour
{

    [SerializeField]
    private VolumeSlider _slider;
    // Start is called before the first frame update
    void Start()
    {
        //_slider.onValueChanged.AddListener(val => SoundManager.Instance.changeMasterVolume(val));
    }

}
