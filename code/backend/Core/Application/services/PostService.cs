using Application.interfaces;
using Application.Utilities.Exceptions;
using Domain;
using Microsoft.Extensions.Logging;

namespace Application.services;

public class PostService : IPostService {
    private readonly IPostDal _postDal;
    private readonly ILogger<PostService> _logger;
    public PostService(IPostDal postDal, ILogger<PostService> logger) {
        _postDal = postDal;
        _logger = logger;
    }

    public async Task<Post> AddPostAsync(Post post) {
        _logger.LogDebug("PostService.AddPostAsync() method is started.");
        var result = GetIfPostExists(post);
        if (!result) {
            throw new PostAlreadyExistsException("Post already exists.");
        }
        await _postDal.AddAsync(post);
        return post;
    }

    public async Task<Post> DeletePostAsync(int postId) {
        _logger.LogDebug("PostService.DeletePostAsync() method is started.");
        var result = GetPostById(postId);
        if (result is null) {
            throw new PostNotFoundException("Post not found!");
        }
        await _postDal.DeleteAsync(result);
        return result;
    }

    public Post? GetPostById(int postId) {
        _logger.LogDebug("PostService.GetPostById() method is initialized.");
        return _postDal.FindById(postId);
    }

    public List<Post> GetPosts() {
        _logger.LogDebug("PostService.GetPosts() method is initialized.");
        return _postDal.GetList().ToList();
    }

    public int GetPostsCount() {
        _logger.LogDebug("PostService.GetPostsCount() method is initialized.");
        return _postDal.GetList().Count;
    }

    public async Task<Post> UpdatePostAsync(Post updatePost) {
        _logger.LogDebug("PostService.UpdatePostAsync() method is initialized.");
        await _postDal.UpdateAsync(updatePost);
        return updatePost;
    }

    private bool GetIfPostExists(Post post) {
        var result = _postDal.Get(x => x.Id == post.Id || x.PostTitle == post.PostTitle);
        return result is null;
    }
}
