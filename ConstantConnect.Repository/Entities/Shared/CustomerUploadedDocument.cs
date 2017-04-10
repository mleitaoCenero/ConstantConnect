using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.Shared
{
    public class CustomerUploadedDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedOn  { get; set; }
        public string ModifiedOn { get; set; }
    }
}
