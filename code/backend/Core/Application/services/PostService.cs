using Application.interfaces;
using Application.Utilities.Exceptions;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.services;

public class PostService : IPostService {
    private readonly IRepository<Post> _repository;
    private readonly ILogger<PostService> _logger;
    public PostService(IRepository<Post> repository, ILogger<PostService> logger) {
        _repository = repository;
        _logger = logger;
    }
    public async Task<Post> AddPostAsync(Post post) {
        _logger.LogDebug("PostService.AddPostAsync() method is started.");
        var result = GetIfPostExists(post);
        if (!result) {
            throw new PostAlreadyExistsException("Post already exists.");
        }
        await _repository.AddAsync(post);
        return post;
    }

    public async Task<Post> DeletePostAsync(int postId) {
        _logger.LogDebug("PostService.DeletePostAsync() method is started.");
        var result = GetPostById(postId);
        if (result is null) {
            throw new PostNotFoundException("Post not found!");
        }
        await _repository.DeleteAsync(result);
        return result;
    }

    public Post? GetPostById(int postId) {
        _logger.LogDebug("PostService.GetPostById() method is initialized.");
        return _repository.FindById(postId);
    }

    public List<Post> GetPosts() {
        _logger.LogDebug("PostService.GetPosts() method is initialized.");
        return _repository.GetList().ToList();
    }

    public int GetPostsCount() {
        _logger.LogDebug("PostService.GetPostsCount() method is initialized.");
        return _repository.GetList().Count;
    }

    public async Task<Post> UpdatePostAsync(Post updatePost) {
        _logger.LogDebug("PostService.UpdatePostAsync() method is initialized.");
        await _repository.UpdateAsync(updatePost);
        return updatePost;
    }

    private bool GetIfPostExists(Post post) {
        var result = _repository.Get(x => x.Id == post.Id && string.Equals(x.PostTitle, post.PostTitle, StringComparison.OrdinalIgnoreCase));
        return result is null;
    }
}
