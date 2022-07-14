﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Blazor.Models
{
    public class Checkout
    {
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        // BillingAddress
        [Required(ErrorMessage = "Please enter a valid address")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }

        // Payment
        [Required]
        public string CardName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string Expiration { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
