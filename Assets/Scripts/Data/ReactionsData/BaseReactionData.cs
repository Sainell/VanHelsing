using System;
using UnityEngine;


namespace BeastHunter
{
    [Serializable]
    public abstract class BaseReactionData : ScriptableObject
    {
        public string Name;
        public string Description;
        virtual public void ActivateReaction(BaseModel model)
        {

        }
    }
}