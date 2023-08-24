using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Pages
{
    public class EditAppointmentPage : PageModel
    {
        private readonly ILogger<EditAppointmentPage> _logger;

        public EditAppointmentPage(ILogger<EditAppointmentPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}