using Application.interfaces;
using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence;

public class PostDal : Repository<Post, UluarsWebContext>, IPostDal {

}
