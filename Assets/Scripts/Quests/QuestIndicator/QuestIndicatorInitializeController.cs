﻿using UnityEngine;


namespace BeastHunter
{
    public sealed class QuestIndicatorInitializeController : IAwake
    {
        #region Field

        GameContext _context;

        #endregion


        #region ClassLifeCycle

        public QuestIndicatorInitializeController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var QuestIndicatorData = Data.QuestIndicatorData;
            var CharacterTransform = _context.CharacterModel.CharacterTransform.transform; //For 3D mode
            var list = Services.SharedInstance.PhysicsService.GetObjectsInRadiusByTag(CharacterTransform.position, 100f, "NPC"); //For 3D mode
            for (int i = 0; i < list.Count; i++) //For 3D mode
            { 
                GameObject instance = GameObject.Instantiate(QuestIndicatorData.QuestIndicatorStruct.Prefab); //For 3D mode
                QuestIndicatorModel QuestIndicator = new QuestIndicatorModel(instance, QuestIndicatorData, list[i].gameObject, _context); //For 3D mode
            //    QuestIndicatorModel QuestIndicator = new QuestIndicatorModel(QuestIndicatorData, _context);
                _context.QuestIndicatorModelList.Add(QuestIndicator); //For 3D mode
                QuestIndicatorData.SetPosition(list[i].transform, instance.transform); //For 3D mode
            }
            Services.SharedInstance.EventManager.TriggerEvent(GameEventTypes.QuestUpdated, null);
        }
        #endregion
    }
}
