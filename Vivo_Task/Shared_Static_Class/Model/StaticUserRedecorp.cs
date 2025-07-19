using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Static_Class.Model
{
    public class StaticUserRedecorp
    {
        public void SetMatricula(int mat)
        {
            matricula = mat;
        }
        public int matricula { get; private set; } = 0;
        public StaticUserRedecorp() 
        {
        }
    }
}
