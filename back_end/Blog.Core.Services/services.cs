using Blog.Core.IRepository;
using Blog.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class services : Iservices
    {
        public readonly Irespository _irespository;
        public services(Irespository irespository)
        {
             _irespository = irespository;
        }

        public int Number(int i, int j)
        {
            var num = _irespository.Num(i, j);
            return num;
        }
    }
}
