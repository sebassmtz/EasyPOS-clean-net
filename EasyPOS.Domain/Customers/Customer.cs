﻿
using EasyPOS.Domain.Primitivies;
using EasyPOS.Domain.ValueObjects;

namespace EasyPOS.Domain.Customers
{
    // Clase sellada que representa un cliente (sealed)
    public sealed class Customer : AggregateRoot
    {
        public Customer(CustomerId id, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool active)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Active = active;
        }

        public Customer()
        {

        }

        public CustomerId Id { get; private set; }
        public string Name { get; private set; } = String.Empty;
        public string LastName { get; private set; } = String.Empty;

        public string FullName => $"{Name} {LastName}";

        public string Email { get; private set; } = String.Empty;

        public PhoneNumber PhoneNumber { get; private set; }

        public Address Address { get; private set; }

        public bool Active { get; private set; }

        public static Customer UpdateCustomer(Guid id, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool active)
        {
            return new Customer(new CustomerId(id), name, lastName, email, phoneNumber, address, active);
        }
    }
}
