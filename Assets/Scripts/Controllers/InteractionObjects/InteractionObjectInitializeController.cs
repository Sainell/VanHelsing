﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BeastHunter
{
    public abstract class InteractionObjectInitializeController : IAwake
    {
        #region Fields

        protected GameContext _context;

        #endregion


        public InteractionObjectInitializeController(GameContext context)
        {
            _context = context;
        }


        public abstract void OnAwake();
    }
}
