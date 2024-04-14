using System;
using System.Collections.Generic;
using Game.GameEngine.InventorySystem;
using GameSystem;
using Windows;
using UnityEngine;

namespace Game.Meta
{
    public sealed class InventoryItemReceiptListPresenter : MonoWindow, IGameConstructElement
    {
        [SerializeField]
        private InventoryItemReceiptCatalog receiptCatalog;

        [SerializeField]
        private InventoryItemReceiptView viewPrefab;

        [SerializeField]
        private Transform container;

        private InventoryItemCrafter craftManager;

        private StackableInventory inventory;

        private readonly List<InventoryItemReceiptPresenter> presenters = new();

        private bool receiptsCreated;

        protected override void OnShow(object args)
        {
            if (!this.receiptsCreated)
            {
                this.CreateReceipts();
                this.receiptsCreated = true;
            }
            
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        protected override void OnHide()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.inventory = context.GetService<InventoryService>().GetInventory();
            this.craftManager = context.GetService<InventoryItemCrafter>();
        }

        private void CreateReceipts()
        {
            var receipts = this.receiptCatalog.GetAllReceipts();
            for (int i = 0, count = receipts.Length; i < count; i++)
            {
                var receipt = receipts[i];
                this.CreateReceipt(receipt);
            }
        }

        private void CreateReceipt(InventoryItemReceipt receipt)
        {
            var view = Instantiate(this.viewPrefab, this.container);
            var presenter = new InventoryItemReceiptPresenter(view, receipt);
            presenter.Construct(this.craftManager, this.inventory);
            this.presenters.Add(presenter);
        }
    }
}