using Domain;

namespace Application.interfaces;

public interface IPostService {
    Task<Post> AddPostAsync(Post post);
    Task<Post> UpdatePostAsync(Post updatePost);
    Task<Post> DeletePostAsync(int postId);
    Post? GetPostById(int postId);
    List<Post> GetPosts();
    int GetPostsCount();

}
