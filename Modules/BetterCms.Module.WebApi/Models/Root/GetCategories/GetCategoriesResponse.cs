﻿using System.Runtime.Serialization;

namespace BetterCms.Module.WebApi.Models.Root.GetCategories
{
    [DataContract]
    public class GetCategoriesResponse : ListResponseBase<CategoryModel>
    {
    }
}