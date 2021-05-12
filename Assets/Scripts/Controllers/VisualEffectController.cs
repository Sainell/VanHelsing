using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeastHunter
{
    public class VisualEffectController
    {
        #region Fields

        private GameContext _context;
        private GameObject _effects;
        private BaseModel _model;
        private Dictionary<string, ParticleSystem> _effectsDic;

        #endregion


        #region ClassLifeCycle

        public VisualEffectController(GameContext context, BaseModel model)
        {
            _context = context;
            _model = model;
            _effects = _model.BuffEffectPrefab;
            _effectsDic = new Dictionary<string, ParticleSystem>();
        }

        #endregion


        #region Methods
        public void OnAwake()
        {
            if (_model != null)
            {
                _model.CurrentStats.BuffHolder.BuffEffectEnable += EnableEffect;
                _model.CurrentStats.BuffHolder.BuffEffectDisable += DisableEffect;
            }

            var effects = _effects.GetComponentsInChildren<ParticleSystem>(false);
            foreach (var effect in effects)
            {
                _effectsDic.Add(effect.name, effect);
            }
        }
        public void Execute()
        {

        }
        public void OnTearDown()
        {
            if (_model != null)
            {
                _model.CurrentStats.BuffHolder.BuffEffectEnable -= EnableEffect;
                _model.CurrentStats.BuffHolder.BuffEffectDisable -= DisableEffect;
            }
        }

        private void EnableEffect(EffectType effectType, BaseBuff buff)
        {
            if (!effectType.Equals(EffectType.None) && _effectsDic.ContainsKey(effectType.ToString()))
            {
                _effectsDic[effectType.ToString()].Play(true);
            }

        }

        private void DisableEffect(EffectType effectType)
        {
            if (!effectType.Equals(EffectType.None) && _effectsDic.ContainsKey(effectType.ToString()))
            {
                _effectsDic[effectType.ToString()].Stop(true);
            }

        }

        #endregion
    }
}