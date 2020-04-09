﻿namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {

        Task<int> CreateAsync(string title, string content, int categoryId, string userId);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        T GetById<T>(int id);

        int GetCountByCategoryId(int categoryId);
    }
}
