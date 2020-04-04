using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Collections;

namespace refresh_docker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["HOSTNAME"] = System.Environment.MachineName;
            ViewData["PROCESSORS"] = System.Environment.ProcessorCount;
            ViewData["OSARCHITECTURE"] = System.Runtime.InteropServices.RuntimeInformation.OSArchitecture;
            ViewData["OSDESCRIPTION"] = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ViewData["PROCESSARCHITECTURE"] = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture;
            ViewData["FRAMEWORKDESCRIPTION"] = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            ViewData["CURRENTDATE"] = System.DateTime.Now;
            
            StringBuilder envVars = new StringBuilder();
            foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                envVars.Append(string.Format("<strong>{0}</strong>:{1}<br \\>", de.Key, de.Value));

            ViewData["ENV_VARS"] = envVars.ToString();
        }
    }
}
