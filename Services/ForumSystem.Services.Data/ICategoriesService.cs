namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);

        T GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);
    }
}
