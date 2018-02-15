using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public CustomerFormViewModel()
        {
        }

        public CustomerFormViewModel(Customer customer)
        {
            Customer = customer;
        }

        public IEnumerable<MembershipType> MembershipTypes => _context.MembershipTypes;
        public Customer Customer { get; set; }
    }
}