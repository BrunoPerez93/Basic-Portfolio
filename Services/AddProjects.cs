using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IRepositorioProjects
    {
        List<Project> ObtainProjects();
    }
    public class AddProjects : IRepositorioProjects
    {
        public List<Project> ObtainProjects()
        {
            return new List<Project>()
          {
              new() {
                  Title = "Deinsa Global",
                  Description = "Create website with React js",
                  ImageURL = "/images/react.webp",
                  Link = "https://www.deinsa.com/",
              },

               new()
              {
                  Title = "Deinsa Global",
                  Description = "Create website with ASP.NET Core",
                  ImageURL = "/images/net.png",
                  Link = "https://adwise.us/",
              },

                new()
              {
                  Title = "Deinsa Global",
                  Description = "Create a chatbot with OpenAI and Next js",
                  ImageURL = "/images/nextjs.jpg",
                  Link = "http://laplazadigital-001-site6.ltempurl.com/",
              },
                  new()
              {
                  Title = "Deinsa Global",
                  Description = "Create a chatbot with OpenAI and Next js",
                  ImageURL = "/images/nextjs.jpg",
                  Link = "http://laplazadigital-001-site6.ltempurl.com/",
              },
          };
        }
    }
}
