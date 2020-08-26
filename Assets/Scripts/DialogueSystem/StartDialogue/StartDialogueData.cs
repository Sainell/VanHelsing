using System;
using System.Collections;
using UnityEngine;


namespace BeastHunter
{
    [CreateAssetMenu(fileName = "NewModel", menuName = "CreateModel/StartDialogue", order = 0)]
    public sealed class StartDialogueData : ScriptableObject
    {
        #region Fields
        public const float CANVAS_OFFSET = 2f;

        public StartDialogueStruct StartDialogueStruct;
        public StartDialogueModel Model;
        public Vector3 NpcPos;
        public int NpcID;
        public int TraceID;
        public DialogueSystemModel DialogueSystemModel;
        public GameObject CanvasNpc;
        public GameObject CanvasTrace;
        public Transform CharacterCamera;
        public string TargetTag;
        public GameObject Trace;
        public bool Flag;
        public bool dialogueStatus;


        #endregion


        #region Events

        public static event Action<bool> ShowCanvasEvent;

        #endregion


        #region Methods

        public void DialogUsing()
        {
            if (Model.IsDialogueAreaEnter)
            {
                if (!DialogueSystemModel.DialogueCanvas.enabled)
                {
                    if (TargetTag.Equals("NPC"))
                    {
                        CanvasNpc.SetActive(true);
                        CanvasNpc.transform.LookAt(GetCharacterCamera());
                    }
                    if (TargetTag.Equals("Trace"))
                    {
                        if (Flag)
                        {
                            CanvasTrace.SetActive(true);
                            CanvasTrace.transform.LookAt(GetCharacterCamera());
                        }
                    }
                }

                if (Input.GetButtonDown("Use"))
                {
                    if (TargetTag.Equals("NPC"))
                    {
                        DialogStatus(true);
                        CanvasNpc.SetActive(false);
                    }
                    if (TargetTag.Equals("Trace"))
                    {
                        TraceStatus(TraceID);
                        CanvasTrace.SetActive(false);
                        Flag = false;
                    }
                }
                if (Input.GetButtonDown("Cancel"))
                {
                    DialogStatus(false);
                    CanvasNpc.SetActive(true);
                }
            }
            else
            {
                if (Model != null)
                {
                    CanvasNpc.SetActive(false);
                    CanvasTrace.SetActive(false);
                    if (DialogueSystemModel.DialogueCanvas.enabled)
                    {
                        DialogStatus(false);
                    }
                }
            }
        }

        private void DialogStatus(bool isShowDialogCanvas)
        {
            DialogueSystemModel.DialogueNode = DialogueGenerate.DialogueCreate(NpcID, Model.Context);
            ShowCanvasEvent?.Invoke(isShowDialogCanvas);
            dialogueStatus = isShowDialogCanvas;
        }

        private void TraceStatus(int id)
        {
            Services.SharedInstance.EventManager.TriggerEvent(GameEventTypes.ObjectUsed, new IdArgs(id));
            TraceOff();
            
        }

        public void DialogAreaEnterSwitcher(bool isOn)
        {
            Model.IsDialogueAreaEnter = isOn;
        }

        private void TraceOff()
        {
            Destroy(Trace);

            CanvasTrace.SetActive(false);
        }

        public Transform GetParent()
        {
            var player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
            return player.transform;
        }

        public void SetPerent(Transform startDialogueTransform, Transform parent)
        {
            startDialogueTransform.parent = parent;
            startDialogueTransform.position = parent.position;
        }

        public void OnTriggerEnter(Collider other)
        {
            TargetTag = other.tag;
            Trace = other.gameObject;
            if (other.tag.Equals("NPC"))
            {
                DialogueSystemModel = Model.Context.DialogueSystemModel;
                var getNpcInfo = other.GetComponent<IGetNpcInfo>().GetInfo();
                NpcID = getNpcInfo.Item1;
                NpcPos = getNpcInfo.Item2;
                CanvasNpc.transform.position = new Vector3(NpcPos.x, NpcPos.y + CANVAS_OFFSET, NpcPos.z);
                DialogAreaEnterSwitcher(true);
                DialogueSystemModel.NpcID = NpcID;
                
            }
            
            if(other.tag.Equals("Trace"))
            {
                Debug.Log("Trace");
                var TraceInfo = other.GetComponent<IGetNpcInfo>().GetInfo();
                TraceID = TraceInfo.Item1;
                var TracePos = TraceInfo.Item2;
                CanvasTrace.transform.position = new Vector3(TracePos.x, TracePos.y + 0.6f, TracePos.z);
                DialogAreaEnterSwitcher(true);
                Flag = true;
            }
        }

        public void OnTriggerExit(Collider other)
        {
            DialogAreaEnterSwitcher(false);
        }

        public void GetDialogueSystemModel(DialogueSystemModel model)
        {
            DialogueSystemModel = model;
        }

        public Transform GetCharacterCamera()
        {
           return Services.SharedInstance.CameraService.CharacterCamera.transform;
        }

        public void OnUpdateDialogueByQuest(EventArgs args)// test updating in dialog
        {
            DialogStatus(true);
        }

        public void OnDialogueStart(int npcId)
        {
            NpcID = npcId;
            if (NpcID == 0)
            {
                DialogStatus(true);
            }
            DialogueSwitcher();
        }

        private void DialogueSwitcher()
        {
            if (!dialogueStatus)
            {
                DialogStatus(true);
            }
            else
            {
                DialogStatus(false);
                NpcID = 0;
            }
        }


        #endregion
    }
}
