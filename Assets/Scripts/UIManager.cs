using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI _liveScore;
    
    [SerializeField]
    private Image _livesImg;
    
    [SerializeField]
    private Sprite[] _basketLives;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _basketLives[currentLives];
    }
}
