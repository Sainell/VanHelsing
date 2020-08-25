using UnityEngine;


namespace BeastHunter
{
    public class TraceController : IUpdate
    {
        #region Fields

        private readonly GameContext _context;

        #endregion


        #region Properties

        public TraceModel Model { get; private set; }

        #endregion


        #region ClassLifeCycle

        public TraceController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region Updating

        public void Updating()
        {
        }

        #endregion
    }
}