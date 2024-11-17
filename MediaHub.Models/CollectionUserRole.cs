﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaHub.Models;
public class CollectionUserRole
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public List<RecommendationCollectionUserAccess> RecommendationCollectionUserAccesses { get; set; } = new List<RecommendationCollectionUserAccess>();
}
