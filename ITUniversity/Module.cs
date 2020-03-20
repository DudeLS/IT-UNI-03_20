using System;
using System.Collections.Generic;

namespace ITUniversity
{
    public abstract class Module
    {
        public IEnumerable<Service> RegisteredServices()
        {
            return new List<Service>();
        }
    }

    public class Service
    {
        public Type TService { get; }

        public Type TImplementation { get; }

        public LiveScope LiveScope { get; }

        public Service(Type service, Type implementation, LiveScope scope)
        {
            TService = service;
            TImplementation = implementation;
            LiveScope = scope;
        }
    }

    public enum LiveScope
    {
        Singleton = 0,

        Transient = 1
    }
}