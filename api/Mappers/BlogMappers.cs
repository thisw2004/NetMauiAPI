using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Blog;
using api.Models;

namespace api.Mappers
{
    public static class BlogMappers
    {
        public static BlogDTO ToBlogDTO(this Blog blogModel){
            return new BlogDTO{
                //set here all data you want to be displayed.
                ID = blogModel.ID,
                Title = blogModel.Title,
                Content = blogModel.Content,
                Author = blogModel.Author,
                Date = blogModel.Date,
                CreatedAt = blogModel.CreatedAt,
                UpdatedAt = blogModel.UpdatedAt
            };
        }

        public static Blog ToBlogFromCreateDTO(this CreateBlogRequestDto BlogDTO){
            return new Blog
            {
                Title = BlogDTO.Title,
                Content = BlogDTO.Content,
                Author = BlogDTO.Author,

            };
        }
    }
}