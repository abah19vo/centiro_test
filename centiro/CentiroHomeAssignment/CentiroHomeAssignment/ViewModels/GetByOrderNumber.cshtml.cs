using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentiroHomeAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CentiroHomeAssignment.ViewModel
{
	public class GetByOrderNumerViewModel : PageModel
    {
        public int OrderNumber { get; set; }
        public OrderModel Order { get; set; }
        public ErrorModel Error { get; set; }

        public void OnGet()
        {
        }
    }
}
