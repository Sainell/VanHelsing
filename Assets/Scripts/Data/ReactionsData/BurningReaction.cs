using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeastHunter
{
    [CreateAssetMenu(fileName = "NewBurningReaction", menuName = "Reactions/BurningReaction")]
    public class BurningReaction : BaseReactionData
    {
        [SerializeField] private BurningReactionEnum _currentReaction;
        private Dictionary<BurningReactionEnum, Action> _reactionDic;
        private BaseModel _model;

        private void OnEnable()
        {
            _reactionDic = new Dictionary<BurningReactionEnum, Action>();
            _reactionDic.Add(BurningReactionEnum.PutOutTheFire, PutOutTheFire);
            _reactionDic.Add(BurningReactionEnum.TestReaction, TestReaction);
        }

        public override void ActivateReaction(BaseModel model)
        {
            _model = model;
            if (_reactionDic.ContainsKey(_currentReaction))
            {
                _reactionDic[_currentReaction].Invoke();
            }
        }

        private void PutOutTheFire()
        {
            if (_model != null && _model is BossModel)
            {
                (_model as BossModel).BossStateMachine.SetCurrentStateAnyway(BossStatesEnum.Standstill, EffectType.Burning);
            }
        }
        private void TestReaction()
        {
            CustomDebug.Log($"Test Reaction on Burning");
        }
    }

    public enum BurningReactionEnum
    {
        None,
        PutOutTheFire,
        TestReaction,

    }
}