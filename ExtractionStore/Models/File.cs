using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExtractionStore.Models
{
    public class File
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name="File Type")]
        public string Type { get; set; }
        public string Data { get; set; }
    }
}