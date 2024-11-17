using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MediaHub.Models
{
    public class User : IdentityUser
    {
        public List<RecommendationCollection> RecommendationCollections { get; set; } = new List<RecommendationCollection>();
        public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccess { get; set; } = new List<RecommendationCollectionUserAccess>();
    }
}
