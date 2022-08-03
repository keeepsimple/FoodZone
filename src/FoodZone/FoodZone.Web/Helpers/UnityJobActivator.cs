using Hangfire;
using System;
using Unity;

namespace FoodZone.Web.Helpers
{
    public class UnityJobActivator: JobActivator
    {
        private IUnityContainer _container;

        public UnityJobActivator(IUnityContainer container)
        {
            _container = container;
        }

        public override object ActivateJob(Type type)
        {
            return _container.Resolve(type);
        }
    }
}