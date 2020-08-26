using UnityEngine;


namespace BeastHunter
{
    public class InteractiveObjectTriggerController : IAwake, ITearDown
    {
        #region Fields

        private readonly GameContext _context;
        private Collider _target;

        #endregion


        #region ClassLifeCycles

        public InteractiveObjectTriggerController(GameContext context)
        {
            _context = context;
        }

        #endregion


        #region IAwake

        public void OnAwake()
        {
            var objects = _context.GetTriggers(InteractableObjectType.InteractiveObject);
            foreach (var trigger in objects)
            {
                var objectBehavior = trigger as InteractiveObjectBehavior;
                objectBehavior.OnFilterHandler += OnFilterHandler;
                objectBehavior.OnTriggerEnterHandler += OnTriggerEnterHandler;
                objectBehavior.OnTriggerExitHandler += OnTriggerExitHandler;
            }
        }

        #endregion


        #region ITearDownController

        public void TearDown()
        {
            var objects = _context.GetTriggers(InteractableObjectType.InteractiveObject);
            foreach (var trigger in objects)
            {
                var objectBehavior = trigger as InteractiveObjectBehavior;
                objectBehavior.OnFilterHandler -= OnFilterHandler;
                objectBehavior.OnTriggerEnterHandler -= OnTriggerEnterHandler;
                objectBehavior.OnTriggerExitHandler -= OnTriggerExitHandler;
            }
        }

        #endregion


        #region Methods

        private bool OnFilterHandler(Collider tagObject)
        {

            return tagObject.CompareTag(TagManager.INTERACTIVE_OBJECT);
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