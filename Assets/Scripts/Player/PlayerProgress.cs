using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;
    public UnityEngine.UI.Image image;
    private int levelValue = 1;
    public TextMeshProUGUI LevelText;
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;
    private void Start() 
    {
        SetLevel(levelValue);
        DrawUI();
    }
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(levelValue + 1);
            _experienceCurrentValue = 0;
        }
        DrawUI();
    }
    private void SetLevel(int value)
    {
        levelValue  = value;

        var currentLevel = levels[levelValue - 1];
        _experienceTargetValue =currentLevel.expForTheNextLvL;
        GetComponent<FireBallCast>().damage =currentLevel.fireballDamage;
        GetComponent<GrenadeCaster>().damage = currentLevel.grenadeDamage;

        var grenadeCaster =GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentLevel.grenadeDamage;


        if(currentLevel.grenadeDamage < 0)
        grenadeCaster.enabled =false;
        else
        grenadeCaster.enabled = true;
        
    }
    private void DrawUI()
    {
        image.fillAmount = _experienceCurrentValue/_experienceTargetValue;
        LevelText.text = levelValue.ToString();
    }
}
