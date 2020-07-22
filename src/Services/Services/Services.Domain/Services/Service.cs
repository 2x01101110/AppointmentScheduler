﻿using BuildingBlocks.Domain;
using Services.Domain.Services.Events;
using System;
using System.Collections.Generic;

namespace Services.Domain.Services
{
    public class Service : Entity<Guid>, IAggregateRoot
    {
        private readonly List<Guid> _services;

        public Guid OrganizationId { get; }
        public string Name { get; private set; }
        public bool CanSelectStaff { get; private set; }
        public bool Available { get; private set; }
        public IReadOnlyCollection<Guid> Services => _services;

        private Service(Guid origanizationId, string name, bool canSelectStaff, bool available)
        {
            this.Id = Guid.NewGuid();
            this.OrganizationId = origanizationId;
            this.Name = name;
            this.CanSelectStaff = canSelectStaff;
            this.Available = available;
            this._services = _services ?? new List<Guid>();

            this.AddDomainEvent(new ServiceCreatedDomainEvent(this));
        }

        public static Service CreateService(Guid origanizationId, string name, bool canSelectStaff, bool available)
        {
            return new Service(origanizationId, name, canSelectStaff, available);
        }

        public void UpdateService(string name, bool canSelectStaff, bool available)
        {
            this.Name = name;
            this.CanSelectStaff = canSelectStaff;
            this.Available = available;

            this.AddDomainEvent(new ServiceUpdatedDomainEvent(this));
        }
    }
}
