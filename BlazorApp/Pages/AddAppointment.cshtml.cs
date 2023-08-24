using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Pages
{
    public class AddAppointment : PageModel
    {
        private readonly ILogger<AddAppointment> _logger;

        public AddAppointment(ILogger<AddAppointment> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}