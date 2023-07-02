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
public class PostController : ApiController {
    private readonly ILogger<PostController> _logger;

    public PostController(ILogger<PostController> logger) {
        _logger = logger;
    }
}
