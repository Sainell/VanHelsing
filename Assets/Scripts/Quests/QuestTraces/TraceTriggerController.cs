using UnityEngine;


namespace BeastHunter
{
    public class TraceTriggerController : IAwake, ITearDown
    {
        #region Fields

        private readonly GameContext _context;
        private Collider _target;

        #endregion


        #region ClassLifeCycles

        public TraceTriggerController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var traces = _context.GetTriggers(InteractableObjectType.Trace);
            foreach (var trigger in traces)
            {
                var traceBehavior = trigger as TraceBehavior;
                traceBehavior.OnFilterHandler += OnFilterHandler;
                traceBehavior.OnTriggerEnterHandler += OnTriggerEnterHandler;
                traceBehavior.OnTriggerExitHandler += OnTriggerExitHandler;
            }
        }

        #endregion


        #region ITearDownController

        public void TearDown()
        {
            var traces = _context.GetTriggers(InteractableObjectType.Trace);
            foreach (var trigger in traces)
            {
                var traceBehavior = trigger as TraceBehavior;
                traceBehavior.OnFilterHandler -= OnFilterHandler;
                traceBehavior.OnTriggerEnterHandler -= OnTriggerEnterHandler;
                traceBehavior.OnTriggerExitHandler -= OnTriggerExitHandler;
            }
        }

        #endregion


        #region Methods

        private bool OnFilterHandler(Collider tagObject)
        {
            return tagObject.CompareTag(TagManager.TRACE);
        }

        private void OnTriggerEnterHandler(ITrigger enteredObject, Collider other)
        {
            enteredObject.IsInteractable = true;
            _context.StartDialogueModel.StartDialogueData.OnTriggerEnter(other);
        }

        private void OnTriggerExitHandler(ITrigger enteredObject, Collider other)
        {
            enteredObject.IsInteractable = false;
            _context.StartDialogueModel.StartDialogueData.OnTriggerExit(other);
        }

        #endregion
    }
}