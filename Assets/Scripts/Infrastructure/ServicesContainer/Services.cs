using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Infrastructure
{
    public class Services
    {
        #region Variables

        private const string Tag = nameof(Services);

        private readonly Dictionary<Type, IService> _services = new();
        private static Services _container;

        #endregion


        #region Properties

        public static Services Container => _container ??= new Services();

        #endregion


        #region Public Methods
        public void Register<TService>(TService implementation) where TService : class, IService
        {
            Type key = typeof(TService);

            if (_services.ContainsKey(key))
            {
                return;
            }
            _services.Add(key, implementation);
        }

        public TService Get<TService>() where TService : class, IService
        {
            Type key = typeof(TService);

            if (_services.ContainsKey(key))
            {
                return _services[key] as TService;
            }
            
            return default;
        }

        public void UnRegister<TService>() where TService : IService
        {
            Type key = typeof(TService);
            if (!_services.ContainsKey(key))
            {
                return;
            }

            _services.Remove(key);
        }

        #endregion
       
    }
}