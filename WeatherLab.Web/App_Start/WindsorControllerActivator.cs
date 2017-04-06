﻿using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace WeatherLab.Web
{
    public class WindsorControllerActivator : IHttpControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerActivator(IWindsorContainer container)
        {
            this._container = container;
        }

        public IHttpController Create(HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller = (IHttpController)this._container.Resolve(controllerType);
            request.RegisterForDispose(new Release(() => this._container.Release(controller)));
            return controller;
        }

        private class Release : IDisposable
        {
            private readonly Action _release;

            public Release(Action release)
            {
                this._release = release;
            }
            public void Dispose()
            {
                this._release();
            }
        }
    }
}