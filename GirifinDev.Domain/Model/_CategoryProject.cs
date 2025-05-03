using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Domain.Model
{
    public class _CategoryProject
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        #region Rel
        public ICollection<_Project> Projects { get; set; }
        #endregion
    }
}
