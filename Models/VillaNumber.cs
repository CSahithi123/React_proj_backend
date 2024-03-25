using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiVilla.Models
{
    public class VillaNumber
    {


        public int Id { get; set; }

        public string VillaName { get; set; }

        public string SpecialDetails { get; set; }


        public int VillaNo { get; set; }

    }
}
