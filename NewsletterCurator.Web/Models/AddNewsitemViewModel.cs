﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Models
{
    public class AddNewsitemViewModel
    {
        public string URL { get; set; }
        public Guid CategoryID { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public List<string> Images { get; set; }
        public string Summary { get; set; }
    }
}
