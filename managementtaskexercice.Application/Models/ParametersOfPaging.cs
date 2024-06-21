using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Models
{
    public class ParametersOfPaging
    {

        private const int _maxSizeOfTasks = 50;
        public int PageNumber { get; set; } = 1;
        private int _numberOfTasks = 10;
        public int NumberOfTasks {



            get
            {
                return _numberOfTasks;
            }

            set
            {
                _numberOfTasks=(value < _maxSizeOfTasks) ? value : _maxSizeOfTasks;
            }
        
        
        
        
        }
    }
}
