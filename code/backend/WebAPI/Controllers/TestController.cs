using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UluarSite.Common.Web;

namespace WebAPI.Controllers;
[Route("[controller]")]
public class TestController : ApiController {
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger) {
        _logger = logger;
    }
}
