using BLL.Filters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryPlotnikova.Models.ReaderModels
{
    public class AllReadersModel
    {
        public ICollection<Reader> Readers { get; set; } = new List<Reader>();
    }
}
