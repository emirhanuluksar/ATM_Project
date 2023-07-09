using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UluarSite.Common.Web;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostController : ApiController {
    private readonly IPostService _postService;
    private readonly ILogger<PostController> _logger;

    public PostController(ILogger<PostController> logger, IPostService postService) {
        _logger = logger;
        _postService = postService;
    }

    [HttpGet("GetAllCategories")]
    public List<Post> GetAllPosts() {
        return _postService.GetPosts();
    }
    [HttpGet("GetPostCategoryById/{id:int}")]
    public Post GetPostById(int id) {
        return _postService.GetPostById(id) ?? new();
    }

    [HttpPost("AddPost")]
    public async Task<CreatedAtActionResult> AddPostAsync(Post post) {
        var result = await _postService.AddPostAsync(post);
        return CreatedAtGetPostById(result);
    }

    private CreatedAtActionResult CreatedAtGetPostById(Post post) {
        return CreatedAtAction(actionName: nameof(GetPostById), routeValues: new { id = post.Id }, value: post);

    }
}

