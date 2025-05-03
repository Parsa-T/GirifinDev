using GirifinDev.Domain.Interface;
using GirifinDev.Domain.Model;
using GirifinDev.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Infra.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        GirifinDevContext _context;
        public CommentRepository(GirifinDevContext context)
        {
            _context = context;
        }
        public void AddComment(_PageComment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
        }

        public int Commentcount()
        {
            return _context.PageComments.Count();
        }
    }
}
