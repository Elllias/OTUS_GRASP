#if UNITY_PURCHASING
using System;
using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace Purchasing
{
    public sealed class PurchaseManager : IStoreListener
    {
        public bool IsInitialized { get; private set; }

        private IStoreController storeController;

        private readonly List<ICompleteListener> completeListeners;

        private readonly List<IFailListener> failListeners;

        private bool isLoading;

        private bool isPurchasing;

        private Action<InitResult> initCallback;

        private Action<PurchaseResult> purchaseCallback;

        public PurchaseManager()
        {
            this.failListeners = new List<IFailListener>();
            this.completeListeners = new List<ICompleteListener>();
        }

        #region Initialize

        public void Initialize(Action<InitResult> callback = null)
        {
            if (this.isLoading)
            {
                throw new Exception("Unity purchasing is already loading!");
            }

            if (this.IsInitialized)
            {
                throw new Exception("Unity Purchasing is already initialized");
            }

            this.initCallback = callback;

            var module = StandardPurchasingModule.Instance();
            var builder = ConfigurationBuilder.Instance(module);
            var productCatalog = ProductCatalog.LoadDefaultCatalog();
            IAPConfigurationHelper.PopulateConfigurationBuilder(ref builder, productCatalog);
            UnityPurchasing.Initialize(this, builder);
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            this.storeController = controller;
            this.isLoading = false;
            this.IsInitialized = true;

            var initResult = new InitResult
            {
                isSuccess = true
            };
            this.initCallback?.Invoke(initResult);
            this.initCallback = null;
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            this.isLoading = false;
            this.IsInitialized = false;

            var initResult = new InitResult
            {
                isSuccess = false,
                error = error
            };
            this.initCallback?.Invoke(initResult);
            this.initCallback = null;
        }

        #endregion

        #region Purchase

        public void Purchase(Product product, Action<PurchaseResult> callback = null)
        {
            this.Purchase(product.definition.id, callback);
        }

        public void Purchase(string productId, Action<PurchaseResult> callback = null)
        {
            if (!this.IsInitialized)
            {
                throw new Exception("Purchasing service is not initialized!");
            }

            if (this.isPurchasing)
            {
                throw new Exception("Other product is purchasing!");
            }

            this.purchaseCallback = callback;
            this.isPurchasing = true;
            this.storeController.InitiatePurchase(productId);
        }

        void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
        {
            this.isPurchasing = false;

            for (int i = 0, count = this.failListeners.Count; i < count; i++)
            {
                var observer = this.failListeners[i];
                observer.OnFailed(product, failureReason);
            }

            var result = new PurchaseResult
            {
                isSuccess = false,
                error = failureReason
            };

            this.purchaseCallback?.Invoke(result);
            this.purchaseCallback = null;
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs args)
        {
            this.isPurchasing = false;

            for (int i = 0, count = this.completeListeners.Count; i < count; i++)
            {
                var observer = this.completeListeners[i];
                observer.OnComplete(args);
            }

            var result = new PurchaseResult
            {
                isSuccess = true
            };

            this.purchaseCallback?.Invoke(result);
            this.purchaseCallback = null;
            return PurchaseProcessingResult.Complete;
        }

        #endregion

        public bool TryGetProduct(string id, out Product product)
        {
            var isInitialized = this.IsInitialized;
            if (isInitialized)
            {
                product = this.storeController.products.WithID(id);
            }
            else
            {
                product = null;
            }

            return isInitialized;
        }

        public bool TryGetAllProducts(out Product[] products)
        {
            var isInitialized = this.IsInitialized;
            if (isInitialized)
            {
                products = this.storeController.products.all;
            }
            else
            {
                products = null;
            }

            return isInitialized;
        }

        public void AddCompleteListeners(IEnumerable<ICompleteListener> listeners)
        {
            this.completeListeners.AddRange(listeners);
        }

        public void AddCompleteListener(ICompleteListener listener)
        {
            this.completeListeners.Add(listener);
        }

        public void AddFailListeners(IEnumerable<IFailListener> listeners)
        {
            this.failListeners.AddRange(listeners);
        }

        public void AddFailListener(IFailListener listener)
        {
            this.failListeners.Add(listener);
        }

        public void RemoveCompleteListener(ICompleteListener listener)
        {
            this.completeListeners.Remove(listener);
        }

        public void RemoveFailListener(IFailListener listener)
        {
            this.failListeners.Remove(listener);
        }
    }
}

#endif