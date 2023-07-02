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
public class CategoryController : ApiController {
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger) {
        _logger = logger;
    }
}

