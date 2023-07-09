using Application.interfaces;
using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence;
public class CategoryDal : Repository<Category, UluarsWebContext>, ICategoryDal {

}

