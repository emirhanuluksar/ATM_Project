using Application.interfaces;
using Domain;
using Persistence.Context;
using Persistence.Repository;

namespace Persistence;

public class ProductDal : Repository<Product, UluarsWebContext>, IProductDal {

}
