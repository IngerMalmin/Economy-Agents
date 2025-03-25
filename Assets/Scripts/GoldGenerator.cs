using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class GoldGenerator : MonoBehaviour
{

    private int currentGold = 0;
    public int goldFromClick = 10;
    public int goldFromSamwise = 300;
    public int goldFromPippin = 100;

    public GameObject videoPlayer;
    public VideoPlayer playVideo;
    public AudioSource sadSadMusic;

    

    [SerializeField] private TextMeshProUGUI score;

    private void Start()
    {
        playVideo.Pause();
    }

    public void CookieClicked()
    {
        currentGold += goldFromClick;
        score.text = currentGold.ToString();
        //uiManager.UpdateGold(currentGold);

    }

    public void PippinClick()
    {
        currentGold += goldFromPippin;
        score.text = currentGold.ToString();
        
    }
    public void SamwiseClick()
    {
        currentGold += goldFromSamwise;
        score.text = currentGold.ToString();
    }
    public void MoreGoldPerClick(int cost)
    {
        if (currentGold >= cost)
        {
            currentGold -= cost;
            goldFromClick += 10;
            score.text = currentGold.ToString();
            //uiManager.UpdateGold(currentGold);
        }
    }

    public void BuyAnAutoClicker(int cost)
    {
        if (currentGold >= cost)
        {
            currentGold -= cost;
            StartCoroutine(AutoClicker());
            score.text = currentGold.ToString();
            //uiManager.UpdateGold(currentGold);
        }
    }
    private IEnumerator AutoClicker()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //Click the cookie
            CookieClicked();
        }
    }

    public void BuySamwise(int cost)
    {
        if (currentGold >= cost)
        {
            currentGold -= cost;
            StartCoroutine(Samwise());
            score.text = currentGold.ToString();
            //uiManager.UpdateGold(currentGold);
        }
    }

    private IEnumerator Samwise()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            SamwiseClick();

        }
    }

    public void HornOfGondor(int cost)
    {
        if (currentGold >= cost)
        {
            Application.Quit();
            
        }
    }

    public void BuyPippin(int cost)
    {
        if (currentGold >= cost)
        {
            currentGold -= cost;
            StartCoroutine(AutoClicker());
            score.text = currentGold.ToString();
            //uiManager.UpdateGold(currentGold);
        }
    }
    private IEnumerator Pippin()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //Click the cookie
            PippinClick();
        }
    }

    public void FavoriteSonBonus(int cost)
    {
        if (currentGold  >= cost)
        {
            currentGold -= cost;
            StartCoroutine(Video());
        }
        
        
    }

    private IEnumerator Video()
    {
        videoPlayer.SetActive(true);
        playVideo.Play();
        sadSadMusic.Pause();
        yield return new WaitForSeconds(22f);
        videoPlayer.SetActive(false);
        sadSadMusic.Play();
    }
}
