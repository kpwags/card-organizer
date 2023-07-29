using System.Collections.Generic;
using CardOrganizer.Domain;
using CardOrganizer.Domain.Models;

namespace CardOrganizer.Application.Repositories;

public interface IBrandRespository : IRepository<Brand>
{
    IEnumerable<Brand> GetBrandsOfType(Constants.CardType cardType);
}