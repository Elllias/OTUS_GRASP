// using System;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
//
// namespace Lessons.Architecture.PM
// {
//     public sealed class UIPopupSkinReward : MonoBehaviour
//     {
//         #region Events
//
//         public event Action OnDispose;
//
//         #endregion
//
//         [SerializeField]
//         private Button buttonAccept;
//
//         [SerializeField]
//         private Button buttonClose;
//
//         [SerializeField]
//         private Image imageIcon;
//
//         [SerializeField]
//         private AudioClip clipReward;
//
//         [SerializeField]
//         private AudioClip clipClick;
//         
//         [SerializeField]
//         private TextMeshProUGUI levelText;
//
//         private SkinItem skinItem;
//
//         #region Lifecycle
//
//         public void Show(SkinItem skinItem)
//         {
//             this.skinItem = skinItem;
//             this.imageIcon.sprite = skinItem.info.spriteIcon;
//         
//             var level = LevelManager.GetPassedLevel();
//             var textLevel = LocalizationManager.GetTranslation("LEVEL");
//             this.levelText.text = textLevel + " " + level;
//         
//             this.buttonAccept.onClick.AddListener(this.OnButtonAcceptClicked);
//             this.buttonClose.onClick.AddListener(this.OnButtonCloseClicked);
//             
//             SoundManager.PlaySound(this.clipReward);
//         }
//
//         public void Hide()
//         {
//             this.buttonAccept.onClick.RemoveListener(this.OnButtonAcceptClicked);
//             this.buttonClose.onClick.RemoveListener(this.OnButtonCloseClicked);
//         }
//
//         #endregion
//
//         #region UICallbacks
//
//         private void OnButtonAcceptClicked()
//         {
//             SkinManager.SelectSkin(this.skinItem);
//             Analytics.LogSkinPopupAccepted(this.skinItem.info.id);
//             SoundManager.PlaySound(this.clipClick);
//             this.OnDispose?.Invoke();
//         }
//
//         private void OnButtonCloseClicked()
//         {
//             Analytics.LogSkinPopupRejected(this.skinItem.info.id);
//             SoundManager.PlaySound(this.clipClick);
//             this.OnDispose?.Invoke();
//         }
//
//         #endregion
//     }
// }
