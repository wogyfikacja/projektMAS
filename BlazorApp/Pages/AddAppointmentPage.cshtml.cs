using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Pages
{
    public class AddAppointmentPage : PageModel
    {
        private readonly ILogger<AddAppointmentPage> _logger;

        public AddAppointmentPage(ILogger<AddAppointmentPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}