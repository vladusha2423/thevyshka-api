using System.Collections.Generic;
using System.Linq;
using TheVyshka.Data.Dto;
using TheVyshka.Data.Entities;

namespace TheVyshka.Data.Converters
{
    public class CategoryConverter
    {
        public static Category Convert(CategoryDto category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public static CategoryDto Convert(Category category)
        {
            var posts = new List<PostDto>();
            if (category.PostCategory != null)
                foreach (var pc in category.PostCategory)
                {
                    pc.Post.PostCategory = null;
                    pc.Post.PostCollaborator = null;
                    pc.Post.PostTag = null;
                    posts.Add(PostConverter.Convert(pc.Post));
                }
            
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Posts = posts
            };
        }
        
        public static List<Category> Convert(List<CategoryDto> category)
        {
            return category.Select(c => Convert(c)).ToList();
        }
        
        public static List<CategoryDto> Convert(List<Category> category)
        {
            return category.Select(c => Convert(c)).ToList();
        }
    }
}