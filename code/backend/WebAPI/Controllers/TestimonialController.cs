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
public class TestimonialController : ApiController {
    private readonly ILogger<TestimonialController> _logger;

    public TestimonialController(ILogger<TestimonialController> logger) {
        _logger = logger;
    }
}

