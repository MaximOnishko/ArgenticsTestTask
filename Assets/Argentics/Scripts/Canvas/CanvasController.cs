﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Argentics._2D
{
    public class CanvasController : Singleton<CanvasController>
    {
        public GameObject[] heartsImage;
        public GameObject SplashScreen;

        public void SetHeartsImage(int countHealth)
        {
            SplashScreen.SetActive(false);

            if (countHealth > heartsImage.Length)
                Debug.LogError("Need adding Heart image");

            foreach (var item in heartsImage)
            {
                item.SetActive(false);
            }
            for (int i = 0; i < countHealth; i++)
            {
                heartsImage[i].SetActive(true);
            }
        }
        public void DecreaseHearts(int damage)
        {
            for (int i = 0; i < damage; i++)
            {
                var image = heartsImage.FirstOrDefault(x => x.activeInHierarchy);

                if (image != null)
                {
                    image.SetActive(false);
                    StartCoroutine(IESplashScreen());
                    
                }

            }
        }
        IEnumerator IESplashScreen()
        {
            SplashScreen.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            SplashScreen.SetActive(false);
        }
        public void IncreaseHearts(int heal)
        {
            for (int i = 0; i < heal; i++)
            {
                var image = heartsImage.FirstOrDefault(x => !x.activeInHierarchy);

                if (image != null)
                    image.SetActive(true);
            }
        }
    }
}
