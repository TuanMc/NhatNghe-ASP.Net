namespace EFCodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public string Id { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Photo { get; set; }
        public bool Activated { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
