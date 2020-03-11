﻿namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Sport", "https://www.bls.gov/spotlight/2017/sports-and-exercise/images/cover_image.jpg"),
                ("Coronavirus", "https://www.hopkinsmedicine.org/-/media/images/health/1_-conditions/infectious-diseases/coronavirus-hero.ashx?h=500&la=en&mh=500&mw=1300&w=1297&hash=6464CC9E4F6364821A5973E670CFB3342C2D9AF4"),
                ("News", "https://media4.s-nbcnews.com/i/newscms/2019_01/2705191/nbc-social-default_b6fa4fef0d31ca7e8bc7ff6d117ca9f4.png"),
                ("Programing", "data:image/png;base64,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"),
                ("Gaming", "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRsQu7wzcW0Ir8-aNzBGlJnHRm_QA7-CZZkVrYOjMXz2mljj0WE"),
                ("Music", "data:image/jpeg;base64,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"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                   Name = category.Name,
                   Title = category.Name,
                   Description = category.Name,
                   ImageUrl = category.ImageUrl,
                });
            }


        }
    }
}
