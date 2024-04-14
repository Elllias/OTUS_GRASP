// using System;
// using TMPro;
// using UnityEngine;
// using UnityEngine.Analytics;
//
// namespace Lessons.Architecture.PM
// {
//     public sealed class SkinRewardPopup : MonoBehaviour
//     {
//         public event Action OnCloseEvent;
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
//         private TextMeshProUGUI levelText;
//
//         [SerializeField]
//         private AudioClip clickSFX;
//
//         private ISkinRewardPresentationModel presentationModel;
//
//         public void Show(ISkinRewardPresentationModel presentationModel)
//         {
//             this.presentationModel = presentationModel;
//             this.imageIcon.sprite = presentationModel.GetSkinIcon();
//             this.levelText.text = presentationModel.GetLevelText();
//
//             this.buttonAccept.onClick.AddListener(this.OnButtonAcceptClicked);
//             this.buttonClose.onClick.AddListener(this.OnButtonCloseClicked);
//
//             SoundManager.PlaySound(this.presentationModel.GetRewardSound());
//         }
//
//         public void Hide()
//         {
//             this.buttonAccept.onClick.RemoveListener(this.OnButtonAcceptClicked);
//             this.buttonClose.onClick.RemoveListener(this.OnButtonCloseClicked);
//         }
//
//         private void OnButtonAcceptClicked()
//         {
//             this.presentationModel.OnAcceptClicked();
//             SoundManager.PlaySound(this.clickSFX);
//
//             this.OnCloseEvent?.Invoke();
//         }
//
//         private void OnButtonCloseClicked()
//         {
//             this.presentationModel.OnCloseClicked();
//             SoundManager.PlaySound(this.clickSFX);
//             this.OnCloseEvent?.Invoke();
//         }
//     }
//
//     public interface ISkinRewardPresentationModel
//     {
//         void OnAcceptClicked();
//
//         void OnCloseClicked();
//
//         Sprite GetSkinIcon();
//
//         string GetLevelText();
//
//         AudioClip GetRewardSound();
//     }
//
//     public sealed class SkinRewardPresentationModel : ISkinRewardPresentationModel
//     {
//         private readonly SkinManager skinManager;
//         private readonly SkinItem skinItem;
//
//         private readonly AudioClip rewardSfx;
//         private readonly AudioClip clickSfx;
//
//         public SkinRewardPresentationModel(
//             SkinManager skinManager,
//             SkinItem skinItem,
//             AudioClip rewardSfx
//         )
//         {
//             this.skinManager = skinManager;
//             this.skinItem = skinItem;
//             this.rewardSfx = rewardSfx;
//         }
//
//         public void OnAcceptClicked()
//         {
//             this.skinManager.SelectSkin(this.skinItem);
//             Analytics.LogSkinPopupAccepted(this.skinItem.info.id);
//         }
//
//         public void OnCloseClicked()
//         {
//             Analytics.LogSkinPopupRejected(this.skinItem.info.id);
//         }
//
//         public Sprite GetSkinIcon()
//         {
//             return this.skinItem.info.spriteIcon;
//         }
//
//         public string GetLevelText()
//         {
//             var levelText = LocalizationManager.GetTranslation("LEVEL");
//             return levelText + " " + LevelManager.GetPassedLevel();
//         }
//
//         public AudioClip GetRewardSound()
//         {
//             return this.rewardSfx;
//         }
//     }
// }