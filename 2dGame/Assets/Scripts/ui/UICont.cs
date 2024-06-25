using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICont : MonoBehaviour
{
    [SerializeField] Image heart1_img, heart2_img, heart3_img;

    [SerializeField] Sprite fullHeart,halfHeart, emptyHeart;

    PlHealthCont plHealthCont;

    [SerializeField] TMP_Text FruitTxt;

    LevelManager levelManager;

    private void Awake()
    {
        plHealthCont = Object.FindObjectOfType<PlHealthCont>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }


    public void updatingHealth()
    {
        switch (plHealthCont.instantHealth)
        {
            case 6:
                heart1_img.sprite = fullHeart;
                heart2_img.sprite = fullHeart;
                heart3_img.sprite = fullHeart;
                break;

            case 5:
                heart1_img.sprite = fullHeart;
                heart2_img.sprite = fullHeart;
                heart3_img.sprite = halfHeart;
                break;

            case 4:
                heart1_img.sprite = fullHeart;
                heart2_img.sprite = fullHeart;
                heart3_img.sprite = emptyHeart;
                break;
            case 3:
                heart1_img.sprite = fullHeart;
                heart2_img.sprite = halfHeart;
                heart3_img.sprite = emptyHeart;
                break;

            case 2:
                heart1_img.sprite = fullHeart;
                heart2_img.sprite = emptyHeart;
                heart3_img.sprite = emptyHeart;
                break;

            case 1:
                heart1_img.sprite = halfHeart;
                heart2_img.sprite = emptyHeart;
                heart3_img.sprite = emptyHeart;
                break;

            case 0:
                heart1_img.sprite = emptyHeart;
                heart2_img.sprite = emptyHeart;
                heart3_img.sprite = emptyHeart;
                break;
        }
            
    }

    public void updatingFruitNum()
    {
        FruitTxt.text = levelManager.collectedFruitNum.ToString();
    }
}
