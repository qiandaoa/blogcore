using Blog.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository
{
    public class respository : Irespository
    {
        public int Num(int i, int j)
        {
            return i + j;
        }
    }
}
