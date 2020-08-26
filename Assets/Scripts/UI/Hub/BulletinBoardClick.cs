﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BeastHunter
{
    public class BulletinBoardClick : MonoBehaviour
    {
        private SpriteRenderer _light;
        private int _questId = 1;
        private void Awake()
        {
            _light = gameObject.transform.Find("Light").GetComponentInChildren<SpriteRenderer>();
        }

        private void OnMouseDown()
        {
            _light.color = new Color(255, 0, 0);
         //   Services.SharedInstance.EventManager.TriggerEvent(GameEventTypes.QuestAccepted, new IdArgs(_questId)); // UI mode
        }
        private void OnMouseUp()
        {
            _light.color = new Color(255, 255, 0);
        }
        private void OnMouseEnter()
        {
            _light.color = new Color(255, 255, 0);
            _light.enabled = true;
        }

        private void OnMouseExit()
        {
            _light.enabled = false;
        }

    }
}