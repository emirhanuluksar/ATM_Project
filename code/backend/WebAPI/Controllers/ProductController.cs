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
public class ProductController : ApiController {
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger) {
        _logger = logger;
    }
}
