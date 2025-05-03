using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Model
{
    public class _Project
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        #region Rel
        [ForeignKey("CategoryId")]
        public virtual _CategoryProject CategoryProject { get; set; }
        #endregion
    }
}
