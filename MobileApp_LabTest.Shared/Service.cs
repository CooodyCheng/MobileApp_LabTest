using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace MobileApp_LabTest.Shared
{
    internal class Service
    {
        [Get("/posts")]
        Task<List<PostRecord>> GetPosts();

        [Post("/posts")]
        Task<PostRecord> CreatePost([Body] PostRecord post);

        [Put("/posts/{id}")]
        Task<PostRecord> UpdatePost(int id, [Body] PostRecord post);

        [Delete("/posts/{id}")]
        Task DeletePost(int id);
    }
}
