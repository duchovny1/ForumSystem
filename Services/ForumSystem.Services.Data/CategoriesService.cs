﻿namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Category> query =
                 this.categoriesRepository.All().OrderBy(x => x.Name);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetByName<T>(string name)
        {
            var result = this.categoriesRepository.All().Where(x => x.Name == name)
                .To<T>().FirstOrDefault();

            return result;
        }

        public T GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}
